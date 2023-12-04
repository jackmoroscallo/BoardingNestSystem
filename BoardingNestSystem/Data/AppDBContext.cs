using BoardingNestSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardingNestSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<BoardingHouse> BoardingHouses { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
