using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RailwayStation.Entity.Modals;

namespace RailwayStation.DataAccess.Database
{
    public class RailwayStationContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public RailwayStationContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<TrainJourney> TrainJourneys { get; private set; }
        public virtual DbSet<TrainStation> TrainStations { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-0IN5JO9S; Database=RailwayStationDB; Trusted_Connection=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<TrainStation>().ToTable("TrainStations");
            modelBuilder.Entity<TrainJourney>().ToTable("TrainJourneys");

            modelBuilder.Entity<TrainJourney>()
                .HasOne(s => s.DepartureStation)
                .WithMany()
                .HasForeignKey(s => s.DepartureStationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainJourney>()
                .HasOne(s => s.ArrivalStation)
                .WithMany()
                .HasForeignKey(s => s.ArrivalStationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainJourney>()
                .HasKey(s => s.JourneyID);

            modelBuilder.Entity<TrainStation>()
                .HasKey(s => s.StationID);
        }
    }
}
