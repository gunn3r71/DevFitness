using DevFitness.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFitness.API.Persistence
{
    public class DevFitnessDbContext : DbContext
    {
        public DevFitnessDbContext(DbContextOptions<DevFitnessDbContext> options) : base (options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                user =>
                {
                    user.HasKey(u => u.Id);
                    user.Property(u => u.Id).ValueGeneratedOnAdd().IsRequired();
                    user.Property(u => u.FullName).HasMaxLength(100).IsRequired();
                    user.Property(u => u.BirthDate).IsRequired();
                    user.Property(u => u.CreatedAt).IsRequired();
                    user.Property(u => u.Active).IsRequired().HasMaxLength(1);
                    user.HasMany(u => u.Meals) //um usuário tem muitas refeições
                        .WithOne()
                        .HasForeignKey(m => m.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<Meal>(
                meal =>
                {
                    meal.HasKey(m => m.Id);
                    meal.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
                    meal.Property(m => m.Description).HasMaxLength(40).IsRequired();
                    meal.Property(m => m.Calories).IsRequired();
                    meal.Property(m => m.Date).IsRequired();
                    meal.Property(m => m.Active).IsRequired().HasMaxLength(1);
                    meal.Property(m => m.CreatedAt).IsRequired();
                }
            );
        }
    }
}
