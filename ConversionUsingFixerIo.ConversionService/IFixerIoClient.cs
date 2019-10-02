using System.Collections.Generic;

namespace ConversionUsingFixerIo.ConversionService
{
    public interface IFixerIoClient
    {
        Dictionary<string, decimal> GetEurBasedRates();
    }
}
