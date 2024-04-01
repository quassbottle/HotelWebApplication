using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomTypeAggregate>
{
    public void Configure(EntityTypeBuilder<RoomTypeAggregate> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(rt => rt.Id);
        builder.Property(rt => rt.Id).ValueGeneratedOnAdd();

        builder
            .HasMany(rt => rt.Rooms)
            .WithOne(r => r.RoomTypeAggregate)
            .HasForeignKey(r => r.RoomTypeId);
    }
}