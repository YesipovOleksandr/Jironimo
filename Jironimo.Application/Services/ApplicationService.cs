using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;

namespace Jironimo.BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public List<Application> GetAplications()
        {
           return _applicationRepository.Get();
        }
    }
}
