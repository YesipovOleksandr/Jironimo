using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using Jironimo.Common.Models.ApplicationDeveloper;
using System.Collections.Generic;

namespace Jironimo.BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationDeveloperRepository _applicationDeveloperRepository;

        public ApplicationService(IApplicationRepository applicationRepository,
                 IApplicationDeveloperRepository applicationDeveloperRepository)
        {
            _applicationRepository = applicationRepository;
            _applicationDeveloperRepository = applicationDeveloperRepository;
        }
        
        public void Create(Application model,List<Guid> developersIds)
        {
            if (model != null)
            {
                var application = _applicationRepository.Create(model);

                foreach (var developerId in developersIds)
                {
                    var newDeveloper = new ApplicationDeveloper
                    {
                        ApplicationId = application,
                        DeveloperId = developerId
                    };
                    _applicationDeveloperRepository.Create(newDeveloper);
                    _applicationDeveloperRepository.Save();
                }
            }
        }

        public Application GetById(Guid applicationId)
        {
            return _applicationRepository.GetById(applicationId);
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

        public List<Application> GetAplicationsWithDetails()
        {
            return _applicationRepository.GetAplicationsWithDetails();
        }

        public List<Application> GetByCategoryId(Guid categoryId)
        {
            return _applicationRepository.GetByCategoryId(categoryId);
        }
    }
}
