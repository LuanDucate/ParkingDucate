using Microsoft.EntityFrameworkCore;
using ParkingDucate.Domain.Model;

namespace ParkingDucate.Domain.Context
{
    public class Context : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}