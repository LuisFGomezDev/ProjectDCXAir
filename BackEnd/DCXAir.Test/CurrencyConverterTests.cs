using DCXAir.Application.Services;
using DCXAir.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Test
{
    [TestFixture]
    public class CurrencyExchangeServiceTests
    {
        private CurrencyExchangeService _currencyExchangeService;
        private Mock<ICurrencyExchangeRepository> _currencyExchangeRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _currencyExchangeRepositoryMock = new Mock<ICurrencyExchangeRepository>();
            _currencyExchangeService = new CurrencyExchangeService(_currencyExchangeRepositoryMock.Object);
        }

        [Test]
        public async Task CurrencyConvert_Converts_USD_To_EUR_Correctly()
        {
            // Arrange
            const string toCurrency = "EUR";
            const decimal usdValue = 100;
            const decimal expectedRate = 0.85m;

            _currencyExchangeRepositoryMock.Setup(x => x.GetConversionRateAsync(toCurrency))
                                           .ReturnsAsync(expectedRate);

            // Act
            var result = await _currencyExchangeService.CurrencyConvert(toCurrency, usdValue);

            // Assert
            Assert.AreEqual(usdValue * expectedRate, result);
        }
        [Test]
        public void CurrencyConvert_Throws_Exception_When_Repository_Fails()
        {
            // Arrange
            const string toCurrency = "EURO";
            const decimal usdValue = 100;

            _currencyExchangeRepositoryMock.Setup(x => x.GetConversionRateAsync(toCurrency))
                                           .ThrowsAsync(new Exception("Failed to retrieve conversion rate"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _currencyExchangeService.CurrencyConvert(toCurrency, usdValue));
        }
    }

}
