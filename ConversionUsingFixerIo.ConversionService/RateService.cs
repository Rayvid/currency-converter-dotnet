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
            _fixerIoClient = fixerIoClient;
        }

        public decimal GetRate(string sourceCurrency, string destinationCurrency)
        {
            throw new System.NotImplementedException(); // No direct conversion
        }

        public decimal GetRateUsingEurAsBase(string sourceCurrency, string destinationCurrency)
        {
            var rates = _fixerIoClient.GetEurBasedRates();
            
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
