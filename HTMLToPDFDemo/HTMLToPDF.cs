using DinkToPdf;

namespace HTMLToPDFDemo
{
    public class HTMLToPDF
    {

        public byte[] ConvertHTMLToPDF(string htmlContent)
        {
            var _converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            },
                Objects = {
                new ObjectSettings()
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            var pdfBytes = _converter.Convert(doc);
            return pdfBytes;
        }
    }
}
