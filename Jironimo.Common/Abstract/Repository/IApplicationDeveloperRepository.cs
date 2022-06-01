using Jironimo.Common.Models.ApplicationDeveloper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationDeveloperRepository
    {
        void Create(ApplicationDeveloper applicationDeveloper);
        public List<ApplicationDeveloper> GetByApplicationsId(Guid applicationId);
        void Delete(Guid id);
        void Save();
    }
}
