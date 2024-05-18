using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Emit;
using TripPlanner.Models;

namespace TripPlanner.Context
{
    public class SeniorDb : DbContext
    {
        public SeniorDb(DbContextOptions<SeniorDb> options) : base(options)
        {
        }

        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<UserTrip> UserTrip { get; set; }
        public DbSet<HouseState> houseStates { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here if needed
            modelBuilder.Entity<Trip>()
               .HasKey(t => t.TripId); // Define the primary key
        }
    }
}
