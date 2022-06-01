using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Developers;

namespace Jironimo.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IApplicationDeveloperRepository _applicationDeveloperRepository;

        public DeveloperService(IDeveloperRepository developerRepository,
            IApplicationDeveloperRepository applicationDeveloperRepository)
        {
            _developerRepository = developerRepository;
            _applicationDeveloperRepository = applicationDeveloperRepository;
        }

        public void Create(Developer developer)
        {
            if (developer != null)
            {
                _developerRepository.Create(developer);
                _developerRepository.Save();
            }
        }

        public void DeleteById(Guid id)
        {
            _developerRepository.Delete(id);
            _developerRepository.Save();
        }

        public Developer GetById(Guid developerId)
        {
            return _developerRepository.GetById(developerId);
        }

        public List<Developer> GetDevelopersByApplicationId(Guid applicationId)
        {
            List<Developer> developers = new List<Developer>();
            var application = _applicationDeveloperRepository.GetByApplicationsId(applicationId);
            foreach (var item in application)
            {
                var developer= _developerRepository.GetById(item.DeveloperId);
                if (developer != null) developers.Add(developer);
            }
            return developers;
        }

        public List<Developer> GetDevelopers()
        {
            return _developerRepository.GetAll();
        }
    }
}
