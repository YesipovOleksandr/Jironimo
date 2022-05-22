using Jironimo.Common.Models.Developer;

namespace Jironimo.Web.Areas.Admin.Models.Developers
{
    public class DeveloperCRUDViewModel
    {
        public DeveloperCreateViewModel DeveloperCreate { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
