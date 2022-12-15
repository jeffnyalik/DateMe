using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Get-values")]
        public string GetValues(string name)
        {
            name = "Software engineering";
            return name;
        }
    }
}