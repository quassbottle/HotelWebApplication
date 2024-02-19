using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(rt => rt.Id);
        builder.Property(rt => rt.Id).ValueGeneratedOnAdd();

        builder
            .HasMany(rt => rt.Rooms)
            .WithOne(r => r.RoomType)
            .HasForeignKey(r => r.RoomTypeId);
    }
}