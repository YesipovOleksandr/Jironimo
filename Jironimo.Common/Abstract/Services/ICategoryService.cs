using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void Create(Category category);
        void DeleteById(Guid id);
    }
}
