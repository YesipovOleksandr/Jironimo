using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Category item)
        {
            var category = _mapper.Map<Entities.Category>(item);
            _context.Category.Add(category);
        }

        public void Updade(Category item)
        {
            var category = _mapper.Map<Entities.Category>(item);
            _context.Category.Update(category);
        }

        public void Delete(Guid id)
        {
            var category = _context.Category.Find(id);
            if (category != null)
                _context.Category.Remove(category);
        }

        public Category Get(Guid CategoryId)
        {
            var category = _context.Category.FirstOrDefault(x => x.Id == CategoryId);
            return _mapper.Map<Category>(category);
        }

        public List<Category> GetAll()
        {
            var categories = _context.Category.ToList();
            return _mapper.Map<List<Category>>(categories);
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
