using Jironimo.Common.Models.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationService
    {
        void Create(Application application);
        List<Application> GetAplications();
        List<Application> GetAplicationsByCategoryId(Guid categoryId);
        void DeleteById(Guid id);
    }
}
