using Microsoft.AspNetCore.Mvc;

namespace UniversityWebAPI.Controllers
{
    [ApiController]          //nos dice que un controlador va a gestionar determinadas rutas
                             //es decir, este controllerbase va a tener una ruta asociada llamada "controller"
    [Route("[controller]")]  //esta ruta nos dice que va hacer localhost:5085/WeatherForecast

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //Method Get: Se hace un Get a la ruta localhost:5085/WeatherForecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}