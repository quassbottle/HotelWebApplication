using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Infrastructure.Configurations;
using HotelWebApplication.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelWebApplication.Infrastructure.Context;

public class DataContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuestConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PreferenceConfiguration());

        modelBuilder.AddPreferences();
        modelBuilder.AddRoomTypes();
    }

    public DbSet<GuestAggregate> Guests { get; set; }
    public DbSet<RoomAggregate> Rooms { get; set; }
    public DbSet<RoomTypeAggregate> RoomTypes { get; set; }
    public DbSet<PreferenceAggregate> Preferences { get; set; }
}