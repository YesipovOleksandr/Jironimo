using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;

namespace Jironimo.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public void Create(Category category)
        {
            if (category != null)
            {
                _categoryRepository.Create(category);
                _categoryRepository.Save();
            }
        }

        public void DeleteById(Guid id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
        }
    }
}
