using Jironimo.Common.Models.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Repository
{
    public interface ICategoryRepository
    {
        Category Get(Guid CategoryId);

        List<Category> GetAll();
    }
}
