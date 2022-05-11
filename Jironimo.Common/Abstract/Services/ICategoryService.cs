using Jironimo.Common.Models.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}
