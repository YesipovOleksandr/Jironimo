using Jironimo.Common.Models.Aplications;

namespace Jironimo.Common.Abstract.Repository
{
    public interface ICategoryRepository
    {
        Category Get(Guid CategoryId);
        List<Category> GetAll();
        void Create(Category item);
        void Updade(Category item); 
        void Delete(Guid id);
        void Save();
    }
}
