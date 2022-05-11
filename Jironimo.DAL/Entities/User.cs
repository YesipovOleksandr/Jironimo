namespace Jironimo.DAL.Entities
{
    public class User : Entity<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
