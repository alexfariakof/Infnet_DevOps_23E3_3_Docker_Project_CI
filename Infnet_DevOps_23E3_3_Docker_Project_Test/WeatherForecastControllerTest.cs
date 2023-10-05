using Infnet_DevOps_23E3_3_Docker_Project.Controllers;
using Infnet_DevOps_23E3_3_Docker_Project;
using Microsoft.Extensions.Logging;
using Moq;

namespace Infnet_DevOps_23E3_3_Docker_Project_Test
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void Get_ReturnsWeatherForecasts()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<WeatherForecast>>(result);
        }

        [Fact]
        public void Post_ReturnsWeatherForecast()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Post();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherForecast>(result);
        }

        [Fact]
        public void Put_ReturnsErroDiveWeatherForecast()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Put();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherForecast>(result);
        }

        [Fact]
        public void Delete_ReturnsWeatherForecast()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Delete();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherForecast>(result);
        }

        [Fact]
        public void TemperatureC_CalculatesCorrectly()
        {
            // Arrange
            var weatherForecast = new WeatherForecast
            {
                TemperatureC = 25
            };

            // Act
            int temperatureC = weatherForecast.TemperatureC;

            // Assert
            int expectedTemperatureF = 32 + (int)(temperatureC / 0.5556);
            Assert.Equal(expectedTemperatureF, weatherForecast.TemperatureF);
        }
    }
}