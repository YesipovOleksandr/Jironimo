using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationService
    {
        void Create(Application application, List<Guid> developersIds);
        List<Application> GetAplications();
        Application GetById(Guid applicationId);
        List<Application> GetAplicationsWithDetails();
        List<Application> GetByCategoryId(Guid categoryId);
        void DeleteById(Guid id);
    }
}
