using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
     
        private readonly ILogger<ConverterController> _logger;

        public ConverterController(ILogger<ConverterController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "HtmlToPdf")]
        public IActionResult Get()
        {
            var topdf = "test";

            var pdfBytes = Converter.BuildPdf(topdf, "8.5in", "11in", new MarginSettings(0, 0, 0, 0));

            return new FileContentResult(pdfBytes, "application/pdf");
        }
    }
}