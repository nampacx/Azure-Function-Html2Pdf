using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Helpers;

namespace WebApplication2.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {

            var topdf = "test";

            var pdfBytes = Converter.BuildPdf(topdf, "8.5in", "11in", new MarginSettings(0, 0, 0, 0));

            return new FileContentResult(pdfBytes, "application/pdf");
        }
    }
}