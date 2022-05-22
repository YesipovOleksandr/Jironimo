using Jironimo.Common.Models.Developer;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IDeveloperRepository
    {
        void Create(Developer developer);
        List<Developer> GetAll();
        void Delete(Guid id);
        void Save();
    }
}
