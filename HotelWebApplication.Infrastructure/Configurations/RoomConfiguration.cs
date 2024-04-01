using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<RoomAggregate>
{
    public void Configure(EntityTypeBuilder<RoomAggregate> builder)
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
            .WithOne(g => g.RoomAggregate)
            .HasForeignKey(g => g.RoomId);
    }
}