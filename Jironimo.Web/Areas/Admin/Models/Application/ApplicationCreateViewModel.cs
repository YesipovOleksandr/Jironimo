using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.Application
{
    public class ApplicationCreateViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile ImagePath { get; set; }
        public int Price { get; set; }
        public string? GooglePlayLink { get; set; }
        public string? AppStoreLink { get; set; }
        [Display(Name = "Out Source")]
        public bool OutSource { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public List<DeveloperListSelect>? Developers { get; set; }
    }
}
