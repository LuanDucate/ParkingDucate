﻿using Microsoft.EntityFrameworkCore;

namespace ParkingDucate.Repository
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }
        
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
