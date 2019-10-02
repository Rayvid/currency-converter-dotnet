using NUnit.Framework;
using FakeItEasy;

namespace ConversionUsingFixerIo.ConversionService.Tests
{
    public class RateServiceTests
    {
        private RateService _rateService;

        [SetUp]
        public void Setup()
        {
            _rateService = new RateService(
                new Microsoft.Extensions.Logging.Abstractions.NullLogger<RateService>(),
                new Fake<IFixerIoClient>().FakedObject);
        }

        [Test]
        public void Test1()
        {
            Assert.That(_rateService.GetRateUsingEurAsBase("EUR", "USD"), Is.EqualTo(1.1));
        }
    }
}