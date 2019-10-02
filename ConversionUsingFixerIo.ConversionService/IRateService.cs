namespace ConversionUsingFixerIo.ConversionService
{
    public interface IRateService
    {
        decimal GetRate(string sourceCurrency, string destinationCurrency);
        decimal GetRateUsingEurAsBase(string sourceCurrency, string destinationCurrency);
    }
}
