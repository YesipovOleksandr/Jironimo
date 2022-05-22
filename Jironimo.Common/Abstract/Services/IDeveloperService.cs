using Jironimo.Common.Models.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Services
{
    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
        void Create(Developer developer);
        void DeleteById(Guid id);
    }
}
