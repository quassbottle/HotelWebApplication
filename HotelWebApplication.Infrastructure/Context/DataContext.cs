using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelWebApplication.Infrastructure.Context;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuestConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PreferenceConfiguration());
    }

    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Preference> Preferences { get; set; }
}