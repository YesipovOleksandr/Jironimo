using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface IApplicationRepository
    {
        List<Application> Get();
        void Add(Application application);
    }
}
