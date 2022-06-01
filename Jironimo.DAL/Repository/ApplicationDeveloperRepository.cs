using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.ApplicationDeveloper;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class ApplicationDeveloperRepository : IApplicationDeveloperRepository
    {

        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationDeveloperRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(ApplicationDeveloper applicationDeveloper)
        {
            var newApplicationDeveloper = _mapper.Map<Entities.ApplicationDeveloper>(applicationDeveloper);
            _context.Add(newApplicationDeveloper);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationDeveloper> GetByApplicationsId(Guid applicationId)
        {
            var applicationDeveloper =_context.ApplicationDeveloper.Where(x => x.ApplicationId == applicationId).ToList();
            var applicationDeveloperEntity = _mapper.Map<List<ApplicationDeveloper>>(applicationDeveloper);
            return applicationDeveloperEntity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}