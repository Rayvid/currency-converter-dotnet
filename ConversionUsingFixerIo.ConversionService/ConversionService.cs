using Microsoft.Extensions.Logging;

namespace ConversionUsingFixerIo.ConversionService
{
    public class ConversionService : IConversionService
    {
        private ILogger _logger;
        private IRateService _rateService;

        public ConversionService(ILogger<ConversionService> logger, IRateService rateService)
        {
            _logger = logger;
            _rateService = rateService;
        }

        public decimal Convert(decimal ammount, string sourceCurrency, string destinationCurrency)
        {
            throw new System.NotImplementedException(); // Not in the scope of assessment
        }
    }
}
