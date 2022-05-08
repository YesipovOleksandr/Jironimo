using Jironimo.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IUserRepository
    {
        User Get(string Login);
        bool Create(User user);
    }
}
