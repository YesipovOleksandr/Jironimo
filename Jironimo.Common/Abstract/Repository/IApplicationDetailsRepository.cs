using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationDetailsRepository
    {
        void Create(ApplicationDetails applicationDetails);
        List<ApplicationDetails> GetById(Guid applicationId);
        void Delete(Guid id);
        void Save();
    }
}
