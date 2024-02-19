using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder
            .HasMany(r => r.Preferences)
            .WithMany(p => p.Rooms)
            .UsingEntity(j => j.ToTable("RoomPreference"));

        builder
            .HasMany(r => r.Guests)
            .WithOne(g => g.Room)
            .HasForeignKey(g => g.RoomId);
    }
}