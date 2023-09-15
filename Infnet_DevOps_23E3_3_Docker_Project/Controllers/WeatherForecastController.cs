using Microsoft.AspNetCore.Mvc;

namespace Infnet_DevOps_23E3_3_Docker_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public WeatherForecast Post()
        {
            var count = 5;

            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55) / count,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        [HttpPut(Name = "PutWeatherForecast")]
        public WeatherForecast Put()
        {
            var count = 8;

            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55) / count,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public WeatherForecast Delete()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}