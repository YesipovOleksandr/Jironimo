using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class ApplicationDetaisRepository : IApplicationDetaisRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationDetaisRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(ApplicationDetails applicationDetails)
        {
            var newApplicationDetails = _mapper.Map<Entities.ApplicationDetails>(applicationDetails);
            _context.Add(newApplicationDetails);
        }

        public List<ApplicationDetails> GetById(Guid applicationId)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.Where(x => x.ApplicationId == applicationId);
            var applicationsDetails = _mapper.Map<List<ApplicationDetails>>(applicationsDetailsEntity);
            return applicationsDetails;
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