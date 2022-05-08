using Jironimo.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Services
{
    public interface IAuthService
    {
        bool Create(User user);
        bool Authenticate(User user);
    }
}
