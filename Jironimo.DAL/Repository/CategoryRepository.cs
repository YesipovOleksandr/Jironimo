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

        public Category Get(Guid CategoryId)
        {
            var category = _context.Сategory.FirstOrDefault(x => x.Id == CategoryId);
            return _mapper.Map<Category>(category);
        }

        public List<Category> GetAll()
        {
            var categories = _context.Сategory.ToList();
            return _mapper.Map<List<Category>>(categories);
        }
    }
}
