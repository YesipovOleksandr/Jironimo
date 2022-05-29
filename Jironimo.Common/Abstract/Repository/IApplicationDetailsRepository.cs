using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationDetailsRepository
    {
        void Create(ApplicationDetails applicationDetails);
        List<ApplicationDetails> GetByIdByApplication(Guid applicationId);
        public ApplicationDetails GetById(Guid id);
        void Delete(Guid id);
        void Save();
    }
}
