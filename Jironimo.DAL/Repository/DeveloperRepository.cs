using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Developers;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public DeveloperRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Developer developer)
        {
            var newDeveloper = _mapper.Map<Entities.Developer>(developer);
            _context.Add(newDeveloper);
        }

        public void Delete(Guid id)
        {
            _context.Remove(id);
        }

        public List<Developer> GetAll()
        {
            var developersEntity = _context.Developers.ToList();
            var developersList = _mapper.Map<List<Developer>>(developersEntity);
            return developersList;
        }

        public List<Developer> GetById(Guid id)
        {

            //var developersEntity = from a in _context.Applications
            //                       join d in _context.Developers on a.Developers equals d.Applications
            //                       select new { Name = d.Name, Position = d.Position, Age = a.ImagePath };

            //var developersList = _mapper.Map<List<Developer>>(developersEntity);
            return null;
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