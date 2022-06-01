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
            var developer = _context.Developers.Find(id);
            if (developer != null)
                _context.Developers.Remove(developer);
        }

        public List<Developer> GetAll()
        {
            var developersEntity = _context.Developers.ToList();
            var developersList = _mapper.Map<List<Developer>>(developersEntity);
            return developersList;
        }

        public Developer GetById(Guid developerId)
        {
            var developerEntity = _context.Developers.FirstOrDefault(x => x.Id == developerId);
            var developer = _mapper.Map<Developer>(developerEntity);
            return developer;
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