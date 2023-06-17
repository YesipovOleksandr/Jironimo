using Jironimo.Common.Models.Aplications;
using Microsoft.VisualBasic;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationService
    {
        void Create(Application model, List<Guid> developersIds);
        void Update(Application model);
        List<Application> GetAplications();
        Application GetById(Guid applicationId);
        Application GetByName(string nameProject);
        List<Application> GetAplicationsWithDetails();
        List<Application> GetByCategoryId(Guid categoryId);
        void DeleteById(Guid id);
    }
}
