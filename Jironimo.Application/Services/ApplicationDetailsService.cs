using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;

namespace Jironimo.BLL.Services
{
    public class ApplicationDetailsService : IApplicationDetailsService
    {
        private readonly IApplicationDetailsRepository _applicationDetailsRepository;
       
        public ApplicationDetailsService(IApplicationDetailsRepository applicationDetailsRepository)
        {
            _applicationDetailsRepository = applicationDetailsRepository;
        }

        public void Create(ApplicationDetails applicationDetails)
        {
            if (applicationDetails != null)
            {
                _applicationDetailsRepository.Create(applicationDetails);
                _applicationDetailsRepository.Save();
            }
        }

        public void DeleteById(Guid id)
        {
            _applicationDetailsRepository.Delete(id);
            _applicationDetailsRepository.Save();
        }

        public List<ApplicationDetails> GetAplicationsDetailsById(Guid applicationId)
        {
            return _applicationDetailsRepository.GetById(applicationId);
        }
    }
}
