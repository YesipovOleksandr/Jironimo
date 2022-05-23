using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Developers;

namespace Jironimo.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
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

        public List<Developer> GetDevelopers()
        {
            return _developerRepository.GetAll();
        }
    }
}
