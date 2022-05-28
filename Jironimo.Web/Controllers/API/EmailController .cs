using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Email;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {

        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendContactForm([FromForm] ContactFromViewModel request)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = request.Email;
            mailRequest.Subject = "Order";
            mailRequest.Body = request.CategoryName + request.Price;
            try
            {
                await mailService.SendEmailAsync(mailRequest);

  
                return Redirect("/");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}