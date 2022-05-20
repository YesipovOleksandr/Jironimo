using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;

namespace Jironimo.BLL.Services
{
    public class ApplicationDetaisService : IApplicationDetaisService
    {
        private readonly IApplicationDetaisRepository _applicationDetaisRepository;
       
        public ApplicationDetaisService(IApplicationDetaisRepository applicationDetaisRepository)
        {
            _applicationDetaisRepository = applicationDetaisRepository;
        }

        public List<ApplicationDetails> GetAplicationsDetailsById(Guid applicationId)
        {
            return _applicationDetaisRepository.GetById(applicationId);
        }
    }
}
