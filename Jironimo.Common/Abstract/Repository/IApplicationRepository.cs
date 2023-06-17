using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
        Application GetById(Guid applicationId);
        Application GetByName(string nameProject);       
        List<Application> GetAplicationsWithDetails();
        Guid Create(Application application);
        List<Application> GetByCategoryId(Guid categoryId);
        void Update(Application model);
        void Save();
        void DeleteById(Guid id);
    }
}
