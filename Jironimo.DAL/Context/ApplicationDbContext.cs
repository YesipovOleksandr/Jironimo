using Jironimo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Jironimo.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationDeveloper> ApplicationDeveloper { get; set; }
        public DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Developer>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Application>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<ApplicationDetails>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Category>().HasMany(x => x.Applications).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Application>().HasMany(x => x.ApplicationDetails).WithOne(x => x.Application).HasForeignKey(x => x.ApplicationId).OnDelete(DeleteBehavior.Cascade);


            builder.Entity<ApplicationDeveloper>().HasKey(ad => new { ad.ApplicationId, ad.DeveloperId });
            builder.Entity<ApplicationDeveloper>().HasOne(ad => ad.Application).WithMany(b => b.ApplicationDeveloper).HasForeignKey(ad => ad.ApplicationId);
            builder.Entity<ApplicationDeveloper>().HasOne(ad => ad.Developer).WithMany(c => c.ApplicationDeveloper).HasForeignKey(ad => ad.DeveloperId);

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name="Mobile" 
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name="Web"
                 }
            );

            builder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Login = "admin",
                Password = "heG64OaMXpPxQyzXzwlbOlQHUSEmkz+/n70ZgSRCOolEF8OMg7zrgF8T5SjT/836"
            }
            );

            base.OnModelCreating(builder);
        }
    }
}

