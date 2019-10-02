using System.Runtime.Serialization;

namespace ConversionUsingFixerIo.ConversionService
{
    public class FixerIoConfig
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "accessKey")]
        public string AccessKey { get; set; }
    }
}
