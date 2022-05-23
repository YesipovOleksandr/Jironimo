using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationService
    {
        void Create(Application application);
        List<Application> GetAplications();
        List<Application> GetAplicationsByCategoryId(Guid categoryId);
        List<Application> GetByIdWithDevelopers(Guid categoryId);
        void DeleteById(Guid id);
    }
}
