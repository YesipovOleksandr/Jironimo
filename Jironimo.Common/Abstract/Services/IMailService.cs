using Jironimo.Common.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }

}
