using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<GuestAggregate>
{
    public void Configure(EntityTypeBuilder<GuestAggregate> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(g => g.RoomAggregate)
            .WithMany(r => r.Guests)
            .HasForeignKey(g => g.RoomId);
    }
}