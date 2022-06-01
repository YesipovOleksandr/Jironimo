using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.DAL.Entities
{
    public class ApplicationDeveloper
    {
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
