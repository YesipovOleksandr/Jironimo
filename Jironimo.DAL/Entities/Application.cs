using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.DAL.Entities
{
    public class Application : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
    }
}
