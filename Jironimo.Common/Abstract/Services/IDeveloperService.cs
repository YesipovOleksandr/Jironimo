using Jironimo.Common.Models.Developers;

namespace Jironimo.Common.Abstract.Services
{
    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
        Developer GetById(Guid developerId);
        List<Developer> GetDevelopersByApplicationId(Guid applicationId);
        void Create(Developer developer);
        void DeleteById(Guid id);
    }
}
