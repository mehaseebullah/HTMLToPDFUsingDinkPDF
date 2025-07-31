using HTMLToPDFDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTMLToPDFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly DinkPdfService _pdfService;

        public CertificateController()
        {
            _pdfService = new DinkPdfService(); // You could inject this via DI
        }

        [HttpGet("generate")]
        public IActionResult Generate(string userName = "Haseeb",
        string courseName = "Advanced C#",
        string completionDate = "31/07/2025")
        {

            var pdfBytes = _pdfService.GenerateCertificate(userName, courseName, completionDate);

            return File(pdfBytes, "application/pdf", "Certificate.pdf");
        }
    }
}
