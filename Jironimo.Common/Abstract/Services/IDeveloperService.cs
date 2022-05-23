using Jironimo.Common.Models.Developers;

namespace Jironimo.Common.Abstract.Services
{
    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
        void Create(Developer developer);
        void DeleteById(Guid id);
    }
}
