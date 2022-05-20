namespace Jironimo.DAL.Entities
{
    public class Application : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public bool Outsource { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Developer> Developers { get; set; }
        public Application()
        {
            Developers = new List<Developer>();
        }
        public ICollection<ApplicationDetails> ApplicationDetails { get; set; }
    }
}
