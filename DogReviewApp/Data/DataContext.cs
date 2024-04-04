using DogReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DogReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Dog> Dog { get; set; }
        public DbSet<DogOwner> DogOwner { get; set; }
        public DbSet<DogCategory> DogCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogCategory>()
                .HasKey(pc => new { pc.DogId, pc.CategoryId });
            modelBuilder.Entity<DogCategory>()
                .HasOne(p => p.Dog)
                .WithMany(pc => pc.DogCategories)
                .HasForeignKey(p => p.DogId);
            modelBuilder.Entity<DogCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.DogCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<DogOwner>()
                .HasKey(po => new { po.DogId, po.OwnerId });
            modelBuilder.Entity<DogOwner>()
                .HasOne(p => p.Dog)
                .WithMany(pc => pc.DogOwners)
                .HasForeignKey(p => p.DogId);
            modelBuilder.Entity<DogOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.DogOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
