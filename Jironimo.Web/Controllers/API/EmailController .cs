using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Email;
using Jironimo.Web.Helper;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IRazorViewToStringRenderer _renderer;
        private readonly IMailService _mailService;
        public EmailController(IMailService mailService, IRazorViewToStringRenderer renderer)
        {
            _mailService = mailService;
            _renderer = renderer;
        }

        [HttpPost]
        public async Task<IActionResult> SendContactForm([FromForm] ContactFromViewModel request)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = request.Email;
            mailRequest.Subject = "Order";
            const string view = "~/Views/TemplatesEmails/ContactForm";
            var htmlBody = await _renderer.RenderViewToStringAsync($"{view}Html.cshtml", request);
            mailRequest.Body = htmlBody;
            try
            {
                await _mailService.SendEmailAsync(mailRequest);

  
                return Redirect("/");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}