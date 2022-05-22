using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.Application
{
    public class ApplicationCreateViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
        [Display(Name = "Position Right")]
        public bool PositionRight { get; set; }
        [Display(Name = "Out Source")]
        public bool OutSource { get; set; }
        public Guid CategoryId { get; set; }
    }
}
