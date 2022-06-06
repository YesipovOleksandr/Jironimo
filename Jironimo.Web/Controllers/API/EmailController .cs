using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Email;
using Jironimo.Web.Helper;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Jironimo.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IRazorViewToStringRenderer _renderer;
        private readonly IMailService _mailService;
        private readonly MailSettings _mailSettings;

        public EmailController(IMailService mailService,
                               IRazorViewToStringRenderer renderer,
                               IOptions<MailSettings> mailSettings)
        {
            _mailService = mailService;
            _renderer = renderer;
            _mailSettings = mailSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SendContactForm([FromForm] ContactFromViewModel request)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = _mailSettings.Mail;
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