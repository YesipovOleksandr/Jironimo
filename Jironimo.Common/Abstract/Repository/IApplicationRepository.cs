using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
        void Create(Application application);
        List<Application> GetByCategoryId(Guid categoryId);
        void Save();
        void DeleteById(Guid id);
    }
}
