using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<Dictionary<string, decimal>> GetEurBasedRates()
        {
            // TODO some caching would be nice
            var httpClient = new HttpClient();

            return JsonConvert.DeserializeObject<Dictionary<string, decimal>>(
                JObject.Parse(await httpClient.GetStringAsync(_fixerIoOptions.Value.Url.Replace("{{access_key}}", _fixerIoOptions.Value.AccessKey)))["rates"].ToString());
        }
    }
}
