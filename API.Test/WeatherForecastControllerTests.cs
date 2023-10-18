using BusinessLab;
using BusinessLab.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace API.Test
{
    public class WeatherForecastControllerTests
    {
        private readonly Mock<ILogger<WeatherForecastController>> _logger;
        private WeatherForecastController _sut;

        public WeatherForecastControllerTests()
        {
            this._logger = new Mock<ILogger<WeatherForecastController>>();
        }

        [SetUp]
        public void Setup()
        {
            this._sut = new WeatherForecastController(this._logger.Object);
        }

        [Test]
        public void Get_WhenItIsRequested_ReturnAnArrayOfWeatherForecast()
        {
            #region Act
            var result = _sut.Get();
            #endregion

            #region Assert
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result, Is.TypeOf<WeatherForecast[]>());
            #endregion
            Assert.Pass();
        }
    }
}