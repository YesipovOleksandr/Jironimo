using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Services
{
    public interface IApplicationDetailsService
    {
        void Create(ApplicationDetails application);
        void DeleteById(Guid id);
        ApplicationDetails GetById(Guid id);
        List<ApplicationDetails> GetAplicationsDetailsById(Guid applicationId);
        List<ApplicationDetails> GetAplicationsDetailsByName(string nameProject);
        
    }
}
