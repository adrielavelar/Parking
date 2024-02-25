using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext()
        {
        }

        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<VacancyConfiguration> VacancyConfigurations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DBCONN");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
