using DinkToPdf;
using DinkToPdf.Contracts;

namespace HTMLToPDFDemo.Services
{
    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService()
        {
            _converter = new SynchronizedConverter(new PdfTools());
        }

        public byte[] GenerateCertificate(string userName, string courseName, string completionDate)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "PdfTemplates", "certificate.html");
            string html = File.ReadAllText(templatePath);

            // Replace placeholders
            html = html.Replace("{{UserName}}", userName)
                       .Replace("{{CourseName}}", courseName)
                       .Replace("{{CompletionDate}}", completionDate);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Landscape,
                Margins = new MarginSettings { Top = 10, Bottom = 10 }
            },
                Objects = {
                new ObjectSettings()
                {
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            return _converter.Convert(doc);
        }
    }
}
