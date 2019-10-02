using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConversionUsingFixerIo.ConversionService
{
    public class RateService : IRateService
    {
        private ILogger<RateService> _logger;
        private IFixerIoClient _fixerIoClient;

        public RateService(ILogger<RateService> logger, IFixerIoClient fixerIoClient)
        {
            _logger = logger;
            _fixerIoClient = fixerIoClient;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<decimal> GetRate(string sourceCurrency, string destinationCurrency)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new System.NotImplementedException(); // No direct conversion
        }

        public async Task<decimal> GetRateUsingEurAsBase(string sourceCurrency, string destinationCurrency)
        {
            var rates = await _fixerIoClient.GetEurBasedRates();
            
            if (!rates.ContainsKey(sourceCurrency.ToUpperInvariant()))
            {
                throw new UnknownCurrencyException(sourceCurrency);
            }

            if (!rates.ContainsKey(destinationCurrency.ToUpperInvariant()))
            {
                throw new UnknownCurrencyException(destinationCurrency);
            }

            return (1 / rates[sourceCurrency.ToUpperInvariant()]) * rates[destinationCurrency.ToUpperInvariant()];
        }
    }
}
