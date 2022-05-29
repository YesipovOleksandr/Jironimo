using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
        Application GetByIdWith(Guid applicationId);
        List<Application> GetAplicationsWithDetails();
        void Create(Application application);
        List<Application> GetByCategoryId(Guid categoryId);
        Application GetByIdWithDevelopers(Guid applicationId);
        void Save();
        void DeleteById(Guid id);
    }
}
