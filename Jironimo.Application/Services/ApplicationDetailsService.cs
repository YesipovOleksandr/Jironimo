using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using System;

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

        public ApplicationDetails GetById(Guid id)
        {
           return _applicationDetailsRepository.GetById(id);
        }

        public void DeleteById(Guid id)
        {
            _applicationDetailsRepository.Delete(id);
            _applicationDetailsRepository.Save();
        }

        public List<ApplicationDetails> GetAplicationsDetailsById(Guid applicationId)
        {
            return _applicationDetailsRepository.GetByIdByApplication(applicationId);
        }

        public List<ApplicationDetails> GetAplicationsDetailsByName(string nameProject)
        {
            return _applicationDetailsRepository.GetAplicationsDetailsByName(nameProject);
        }
    }
}
