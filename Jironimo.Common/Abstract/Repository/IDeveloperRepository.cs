using Jironimo.Common.Models.Developers;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IDeveloperRepository
    {
        void Create(Developer developer);
        List<Developer> GetAll();
        void Delete(Guid id);
        void Save();
        Developer GetById(Guid developerId);
    }
}
