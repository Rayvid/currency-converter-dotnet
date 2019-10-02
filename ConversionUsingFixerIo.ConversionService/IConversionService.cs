namespace ConversionUsingFixerIo.ConversionService
{
    public interface IConversionService
    {
        decimal Convert(decimal ammount, string sourceCurrency, string destinationCurrency);
    }
}
