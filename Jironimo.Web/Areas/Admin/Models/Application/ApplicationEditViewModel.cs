using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.Application
{
    public class ApplicationEditViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public IFormFile ImageFormFile { get; set; }
        public int? Price { get; set; }
        public string? GooglePlayLink { get; set; }
        public string? AppStoreLink { get; set; }
        public bool OutSource { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
    }
}
