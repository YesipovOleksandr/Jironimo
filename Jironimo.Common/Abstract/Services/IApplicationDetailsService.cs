using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationDetailsService
    {
        void Create(ApplicationDetails application);
        void DeleteById(Guid id);
        List<ApplicationDetails> GetAplicationsDetailsById(Guid applicationId);
    }
}
