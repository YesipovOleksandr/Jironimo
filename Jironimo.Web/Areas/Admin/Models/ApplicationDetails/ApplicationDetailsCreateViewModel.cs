using Jironimo.Common.Models.Aplications;
using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.ApplicationDetails
{
    public class ApplicationDetailsCreateViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public IFormFile ImagePath { get; set; }
        public IFormFile? ImagePathTwo { get; set; }
        public PositionImage PositionImage { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
