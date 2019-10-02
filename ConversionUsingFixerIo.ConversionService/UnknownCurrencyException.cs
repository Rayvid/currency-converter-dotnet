using System;

namespace ConversionUsingFixerIo.ConversionService
{
    public class UnknownCurrencyException : Exception
    {
        public UnknownCurrencyException(string currencyName, Exception innerException = null)
            : base(string.Format("Unknown currency {0}", currencyName), innerException)
        {
        }
    }
}
