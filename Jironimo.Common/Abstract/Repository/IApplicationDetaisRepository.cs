using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationDetaisRepository
    {
        void Create(ApplicationDetails applicationDetails);
        List<ApplicationDetails> GetById(Guid applicationId);
        void Save();
    }
}
