using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
        void Add(Application application);
        List<Application> GetByCategoryId(Guid categoryId);
    }
}
