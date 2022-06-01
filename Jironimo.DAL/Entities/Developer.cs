using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.DAL.Entities
{
    public class Developer : Entity<Guid>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Position { get; set; }
        public ICollection<ApplicationDeveloper> ApplicationDeveloper { get; set; }
    }
}
