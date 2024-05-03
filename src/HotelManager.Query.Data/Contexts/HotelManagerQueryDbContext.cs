using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Data.Contexts
{
    public class HotelManagerQueryDbContext : DbContext
    {
        public HotelManagerQueryDbContext(DbContextOptions<HotelManagerQueryDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomValue> RoomValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelManagerQueryDbContext).Assembly);
        }
    }
}