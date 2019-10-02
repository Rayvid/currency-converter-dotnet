using ConversionUsingFixerIo.ConversionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConversionUsingFixerIo.ConsoleHost
{
    class ConsoleHost
    {
        // Modern shell for .NET core based apps
        static void Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
#if DEBUG
                    config.AddJsonFile("appsettings.dev.json", optional: true);
#endif
                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<FixerIoConfig>(hostContext.Configuration.GetSection("FixerIo"));

                    services.AddLogging();
                    services.AddOptions();
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IRateService, RateService>();
                    services.AddSingleton<IFixerIoClient, FixerIoClient>();
                })
                .ConfigureLogging((hostingContext, logging) => {
                    logging.ClearProviders();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            var host = builder.Build();
            var logger = host.Services.GetService<ILogger<ConsoleHost>>();
            var test = host.Services.GetService<IRateService>();
            host.Services.GetService<ILogger<ConsoleHost>>().LogDebug("Starting host");

            var cts = new CancellationTokenSource();
            host.RunAsync(cts.Token);

            Console.WriteLine("Press <ENTER> to exit");
            ConsoleKeyInfo? key = null;
            do
            {
                key = Console.ReadKey();
            } while (key.Value.Key != ConsoleKey.Enter);
            cts.Cancel();
        }

        // Actual worker
        public class Worker : IHostedService, IDisposable
        {
            private Task _executingTask;
            private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
            private ILogger _logger;

            public Worker(ILogger<Worker> logger)
            {
                _logger = logger;
            }

            protected Task ExecuteAsync(CancellationToken stoppingToken)
            {
                _logger.LogDebug("Test");
                return Task.FromResult(0);
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogDebug("Starting hosted service");

                // Store the task we're executing
                _executingTask = ExecuteAsync(_stoppingCts.Token);

                // Otherwise it's running
                return Task.CompletedTask;
            }

            public virtual async Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogDebug("Stopping hosted service");

                // Stop called without start
                if (_executingTask == null)
                {
                    return;
                }

                try
                {
                    // Signal cancellation to the executing method
                    _stoppingCts.Cancel();
                }
                finally
                {
                    // Wait until the task completes or the stop token triggers
                    await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
                }
            }

            public virtual void Dispose()
            {
                _stoppingCts.Cancel();
            }
        }
    }
}
