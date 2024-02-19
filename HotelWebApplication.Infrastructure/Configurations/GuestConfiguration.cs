using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(g => g.Room)
            .WithMany(r => r.Guests)
            .HasForeignKey(g => g.RoomId);
    }
}