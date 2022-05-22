using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.Developers
{
    public class DeveloperCreateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
