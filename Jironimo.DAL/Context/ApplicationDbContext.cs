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
        public DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Developer>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Application>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<ApplicationDetails>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Category>().HasMany(x => x.Applications).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Application>().HasMany(x => x.ApplicationDetails).WithOne(x => x.Application).HasForeignKey(x => x.ApplicationId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}

