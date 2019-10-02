using System.Threading.Tasks;

namespace ConversionUsingFixerIo.ConversionService
{
    public interface IRateService
    {
        Task<decimal> GetRate(string sourceCurrency, string destinationCurrency);
        Task<decimal> GetRateUsingEurAsBase(string sourceCurrency, string destinationCurrency);
    }
}
