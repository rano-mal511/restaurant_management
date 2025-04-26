using Microsoft.EntityFrameworkCore;
using restaurant_management.Models;

namespace restaurant_management.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Tables)
                .WithOne(t => t.Restaurant)
                .HasForeignKey(t => t.RestaurantId);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.MenuItems)
                .WithOne(m => m.Restaurant)
                .HasForeignKey(m => m.RestaurantId);

            modelBuilder.Entity<Table>()
                .HasMany(t => t.Reservations)
                .WithOne(r => r.Table)
                .HasForeignKey(r => r.TableId);

            modelBuilder.Entity<Table>()
                .HasIndex(t => t.TableNumber);

            modelBuilder.Entity<Reservation>()
                .HasIndex(r => r.ReservationDate);
        }
    }
}