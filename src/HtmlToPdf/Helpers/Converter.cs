using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPdf.Helpers
{
    public static class Converter
    {

        // Read more about converter on: https://github.com/rdvojmoc/DinkToPdf
        // For our purposes we are going to use SynchronizedConverter
        private static IConverter pdfConverter = new SynchronizedConverter(new PdfTools());

        // A function to convert html content to pdf based on the configuration passed as arguments
        // Arguments:
        // HtmlContent: the html content to be converted
        // Width: the width of the pdf to be created. e.g. "8.5in", "21.59cm" etc.
        // Height: the height of the pdf to be created. e.g. "11in", "27.94cm" etc.
        // Margins: the margis around the content
        // DPI: The dpi is very important when you want to print the pdf.
        // Returns a byte array of the pdf which can be stored as a file
        public static byte[] BuildPdf(string HtmlContent, string Width, string Height, MarginSettings Margins, int? DPI = 180)
        {
            // Call the Convert method of SynchronizedConverter "pdfConverter"
            return pdfConverter.Convert(new HtmlToPdfDocument()
            {
                // Set the html content
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = HtmlContent
                    }
                },
                // Set the configurations
                GlobalSettings = new GlobalSettings
                {
                    // PaperKind.A4 can also be used instead PechkinPaperSize
                    PaperSize = new PechkinPaperSize(Width, Height),
                    DPI = DPI,
                    Margins = Margins
                }
            });
        }
    }
}
