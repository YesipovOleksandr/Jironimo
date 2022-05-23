using Jironimo.Common.Models.Developers;
namespace Jironimo.Common.Models.Aplications
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public bool OutSource { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}

