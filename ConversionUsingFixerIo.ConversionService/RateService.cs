using Microsoft.Extensions.Logging;

namespace ConversionUsingFixerIo.ConversionService
{
    public class RateService : IRateService
    {
        private ILogger<RateService> _logger;
        private IFixerIoClient _fixerIoClient;

        public RateService(ILogger<RateService> logger, IFixerIoClient fixerIoClient)
        {
            _logger = logger;
        }

        public decimal GetRate(string sourceCurrency, string destinationCurrency)
        {
            throw new System.NotImplementedException(); // No direct conversion
        }

        public decimal GetRateUsingEurAsBase(string sourceCurrency, string destinationCurrency)
        {
            var rates = _fixerIoClient.GetEurBasedRates();
            return (1 / rates[sourceCurrency.ToUpperInvariant()]) * rates[destinationCurrency.ToUpperInvariant()];
        }
    }
}
