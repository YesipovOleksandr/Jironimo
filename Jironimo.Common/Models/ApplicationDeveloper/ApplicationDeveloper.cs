using Jironimo.Common.Models.Aplications;
using Jironimo.Common.Models.Developers;

namespace Jironimo.Common.Models.ApplicationDeveloper
{
    public class ApplicationDeveloper
    {
        public Guid DeveloperId { get; set; }
        public Guid ApplicationId { get; set; }

        public Developer Developer { get; set; }
        public Application Application { get; set; }
    }
}
