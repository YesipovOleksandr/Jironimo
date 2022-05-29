using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Jironimo.DAL.Repository
{
    public class ApplicationDetailsRepository : IApplicationDetailsRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationDetailsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(ApplicationDetails applicationDetails)
        {
            var newApplicationDetails = _mapper.Map<Entities.ApplicationDetails>(applicationDetails);
            _context.Add(newApplicationDetails);
        }

        public List<ApplicationDetails> GetByIdByApplication(Guid applicationId)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.Where(x => x.ApplicationId == applicationId);
            var applicationsDetails = _mapper.Map<List<ApplicationDetails>>(applicationsDetailsEntity);
            return applicationsDetails;
        }

        public ApplicationDetails GetById(Guid id)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.Where(x => x.Id == id);
            var applicationsDetails = _mapper.Map<ApplicationDetails>(applicationsDetailsEntity);
            return applicationsDetails;
        }

        public void Delete(Guid id)
        {
            _context.Remove(id);
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