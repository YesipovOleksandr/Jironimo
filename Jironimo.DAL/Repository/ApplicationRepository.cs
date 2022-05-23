using AutoMapper;
using Jironimo.Common.Abstract;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Jironimo.DAL.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Application application)
        {
            var newApplication = _mapper.Map<Entities.Application>(application);
            _context.Add(newApplication);
        }

        public List<Application> GetAll()
        {
            var applicationsEntity = _context.Applications.Include(a => a.Category).ToList();
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }

        public List<Application> GetByCategoryId(Guid categoryId)
        {
            var applicationsEntity = _context.Applications.Where(x => x.CategoryId == categoryId);
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }

        public List<Application> GetByIdWithDevelopers(Guid applicationId)
        {
            var applicationsEntity = _context.Applications.Include(d => d.Developers).Where(x => x.Id == applicationId).ToList();
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }

        public void DeleteById(Guid id)
        {
            var application = _context.Applications.Find(id);
            if (application != null)
                _context.Applications.Remove(application);
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