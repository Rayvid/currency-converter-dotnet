using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConversionUsingFixerIo.ConversionService
{
    public interface IFixerIoClient
    {
        Task<Dictionary<string, decimal>> GetEurBasedRates();
    }
}
