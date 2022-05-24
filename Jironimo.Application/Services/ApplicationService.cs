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

        public void Create(Application application)
        {
            if (application != null)
            {
                _applicationRepository.Create(application);
                _applicationRepository.Save();
            }
        }

        public void DeleteById(Guid id)
        {
            _applicationRepository.DeleteById(id);
            _applicationRepository.Save();
        }

        public List<Application> GetAplications()
        {
            return _applicationRepository.GetAll();
        }

        public List<Application> GetAplicationsByCategoryId(Guid categoryId)
        {
            return _applicationRepository.GetByCategoryId(categoryId);
        }

        public Application GetByIdWithDevelopers(Guid applicationId)
        {
            return _applicationRepository.GetByIdWithDevelopers(applicationId);
        }     
    }
}
