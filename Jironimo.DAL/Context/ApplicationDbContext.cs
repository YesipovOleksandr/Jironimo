using Jironimo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jironimo.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Сategory> Сategory { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Сategory>().HasMany(x => x.Applications).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}

