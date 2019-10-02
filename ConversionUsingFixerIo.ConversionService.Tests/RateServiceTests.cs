using NUnit.Framework;
using FakeItEasy;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ConversionUsingFixerIo.ConversionService.Tests
{
    public class RateServiceTests
    {
        private RateService _rateService;

        [SetUp]
        public void Setup()
        {
            var fixerIoClientMock = new Fake<IFixerIoClient>();
            _rateService = new RateService(
                new Microsoft.Extensions.Logging.Abstractions.NullLogger<RateService>(),
                fixerIoClientMock.FakedObject);
            var mockedResponse = @"
{
  ""success"":true,
  ""timestamp"":1570003747,
  ""base"":""EUR"",
  ""date"":""2019-10-02"",
  ""rates"":{
    ""AED"":4.008976,
    ""AFN"":85.266296,
    ""ALL"":122.081843,
    ""AMD"":518.707939,
    ""ANG"":1.91216,
    ""AOA"":412.610384,
    ""ARS"":62.914919,
    ""AUD"":1.629899,
    ""AWG"":1.965749,
    ""AZN"":1.861021,
    ""BAM"":1.954781,
    ""BBD"":2.199762,
    ""BDT"":92.056782,
    ""BGN"":1.955817,
    ""BHD"":0.411503,
    ""BIF"":2013.392437,
    ""BMD"":1.091477,
    ""BND"":1.510278,
    ""BOB"":7.533863,
    ""BRL"":4.53776,
    ""BSD"":1.089523,
    ""BTC"":0.000133,
    ""BTN"":77.36878,
    ""BWP"":12.046086,
    ""BYN"":2.270052,
    ""BYR"":21392.942712,
    ""BZD"":2.196026,
    ""CAD"":1.443936,
    ""CDF"":1817.308598,
    ""CHF"":1.089623,
    ""CLF"":0.028868,
    ""CLP"":796.554249,
    ""CNY"":7.802313,
    ""COP"":3791.407931,
    ""CRC"":633.176251,
    ""CUC"":1.091477,
    ""CUP"":28.924132,
    ""CVE"":110.217311,
    ""CZK"":25.739863,
    ""DJF"":193.977226,
    ""DKK"":7.465782,
    ""DOP"":56.937422,
    ""DZD"":131.550238,
    ""EGP"":17.78561,
    ""ERN"":16.372243,
    ""ETB"":31.903758,
    ""EUR"":1,
    ""FJD"":2.399447,
    ""FKP"":0.887239,
    ""GBP"":0.889442,
    ""GEL"":3.25811,
    ""GGP"":0.889452,
    ""GHS"":5.872308,
    ""GIP"":0.887239,
    ""GMD"":55.119162,
    ""GNF"":10069.800112,
    ""GTQ"":8.421779,
    ""GYD"":227.938546,
    ""HKD"":8.557014,
    ""HNL"":26.816463,
    ""HRK"":7.413637,
    ""HTG"":104.757729,
    ""HUF"":334.89457,
    ""IDR"":15493.511316,
    ""ILS"":3.805881,
    ""IMP"":0.889452,
    ""INR"":77.801276,
    ""IQD"":1300.05786,
    ""IRR"":45956.625175,
    ""ISK"":135.507119,
    ""JEP"":0.889452,
    ""JMD"":146.13902,
    ""JOD"":0.774078,
    ""JPY"":117.50806,
    ""KES"":113.36135,
    ""KGS"":76.064788,
    ""KHR"":4476.248567,
    ""KMF"":491.491165,
    ""KPW"":982.41808,
    ""KRW"":1315.404037,
    ""KWD"":0.3323,
    ""KYD"":0.907939,
    ""KZT"":423.405369,
    ""LAK"":9611.598351,
    ""LBP"":1647.363336,
    ""LKR"":198.512311,
    ""LRD"":228.25504,
    ""LSL"":16.721169,
    ""LTL"":3.222847,
    ""LVL"":0.660223,
    ""LYD"":1.543294,
    ""MAD"":10.619577,
    ""MDL"":19.300037,
    ""MGA"":4063.783335,
    ""MKD"":61.500378,
    ""MMK"":1669.140336,
    ""MNT"":2911.338742,
    ""MOP"":8.798666,
    ""MRO"":389.657548,
    ""MUR"":39.91039,
    ""MVR"":16.807886,
    ""MWK"":798.595252,
    ""MXN"":21.667773,
    ""MYR"":4.574491,
    ""MZN"":67.628287,
    ""NAD"":16.732395,
    ""NGN"":395.11449,
    ""NIO"":36.623398,
    ""NOK"":9.983627,
    ""NPR"":123.789845,
    ""NZD"":1.747565,
    ""OMR"":0.420213,
    ""PAB"":1.089523,
    ""PEN"":3.671564,
    ""PGK"":3.708237,
    ""PHP"":56.747507,
    ""PKR"":170.86519,
    ""PLN"":4.380696,
    ""PYG"":6951.123624,
    ""QAR"":3.974119,
    ""RON"":4.748684,
    ""RSD"":117.453423,
    ""RUB"":71.46869,
    ""RWF"":1007.869556,
    ""SAR"":4.094349,
    ""SBD"":9.067877,
    ""SCR"":14.954308,
    ""SDG"":49.149742,
    ""SEK"":10.808912,
    ""SGD"":1.511848,
    ""SHP"":1.441735,
    ""SLL"":10423.602373,
    ""SOS"":633.056833,
    ""SRD"":8.140251,
    ""STD"":23533.09925,
    ""SVC"":9.533012,
    ""SYP"":562.11051,
    ""SZL"":16.687545,
    ""THB"":33.464365,
    ""TJS"":10.557472,
    ""TMT"":3.820168,
    ""TND"":3.128719,
    ""TOP"":2.546688,
    ""TRY"":6.265666,
    ""TTD"":7.38444,
    ""TWD"":33.913814,
    ""TZS"":2503.730392,
    ""UAH"":26.727025,
    ""UGX"":4012.596367,
    ""USD"":1.091477,
    ""UYU"":40.163615,
    ""UZS"":10292.024801,
    ""VEF"":10.901124,
    ""VND"":25278.599654,
    ""VUV"":129.093522,
    ""WST"":2.943554,
    ""XAF"":655.62795,
    ""XAG"":0.063237,
    ""XAU"":0.000737,
    ""XCD"":2.94977,
    ""XDR"":0.800852,
    ""XOF"":655.628188,
    ""XPF"":119.199801,
    ""YER"":273.186025,
    ""ZAR"":16.791343,
    ""ZMK"":9824.583546,
    ""ZMW"":14.201746,
    ""ZWL"":351.455489
  }
}";
            var eurBasedRates = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(
                JObject.Parse(mockedResponse)["rates"].ToString());
            fixerIoClientMock.CallsTo(_ => _.GetEurBasedRates()).Returns(Task.FromResult(eurBasedRates));
        }

        [TestCase("EUR", "USD", 1.091477)]
        [TestCase("GbP", "uSd", 1.2271480321370027500387883639)]
        public void GivenKnownEurBasedRates_TestHappyFlow(string from, string to, decimal expectedRate)
        {
            Assert.That(Math.Round(_rateService.GetRateUsingEurAsBase(from, to).Result, 14), Is.EqualTo(expectedRate));
        }

        [TestCase("EUR", "USDa", true)]
        [TestCase("EURa", "USD", true)]
        [TestCase("GbP", "uSd", false)]
        public void GivenKnownEurBasedRates_TestErrorHandling(string from, string to, bool isUnknownCurrencyThrown)
        {
            if (isUnknownCurrencyThrown)
            {
                Assert.That(() => Math.Round(_rateService.GetRateUsingEurAsBase(from, to).Result, 14),
                    Throws.TypeOf(typeof(AggregateException)).And.InnerException.TypeOf(typeof(UnknownCurrencyException)));
            }
            else
            {
                Assert.That(() => Math.Round(_rateService.GetRateUsingEurAsBase(from, to).Result, 14), Throws.Nothing);
            }
        }
    }
}