namespace Jironimo.DAL.Entities
{
    public class Application : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Сategory Category { get; set; }
    }
}
