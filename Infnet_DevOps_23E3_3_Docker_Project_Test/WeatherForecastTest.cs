using Infnet_DevOps_23E3_3_Docker_Project;

namespace Infnet_DevOps_23E3_3_Docker_Project_Test
{

    public class WeatherForecastTests
    {
        [Theory]
        [InlineData(0, 32)]
        [InlineData(25, 76)]
        [InlineData(100, 211)]
        [InlineData(-10, 15)]
        public void TemperatureF_ConvertsCorrectly(int temperatureC, int expectedTemperatureF)
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = temperatureC };

            // Act
            int actualTemperatureF = weatherForecast.TemperatureF;

            // Assert
            Assert.Equal(expectedTemperatureF, actualTemperatureF);
        }
    }
}