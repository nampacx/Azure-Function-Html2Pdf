using DinkToPdf;
using HtmlToPdf.DataContracts;
using HtmlToPdf.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HtmlToPdf
{
    public static class HtmlToPdfFunction
    {
        [FunctionName("HtmlToPdf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] Html2PdfRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                var topdf = req?.HtmlContent ?? "test";

                var pdfBytes = Converter.BuildPdf(topdf, "8.5in", "11in", new MarginSettings(0, 0, 0, 0));

                return new FileContentResult(pdfBytes, "application/pdf");
            }
            catch(Exception e)
            {
                log.LogError(e, "Error");
                throw;
            }
        }
    }
}
