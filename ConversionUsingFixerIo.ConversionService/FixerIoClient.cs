using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ConversionUsingFixerIo.ConversionService
{
    public class FixerIoClient : IFixerIoClient
    {
        private ILogger<RateService> _logger;
        private IOptions<FixerIoConfig> _fixerIoOptions;

        public FixerIoClient(ILogger<RateService> logger, IOptions<FixerIoConfig> fixerIoOptions)
        {
            _logger = logger;
            _fixerIoOptions = fixerIoOptions;
        }

        public Dictionary<string, decimal> GetEurBasedRates()
        {
            return new Dictionary<string, decimal>();
        }
    }
}
