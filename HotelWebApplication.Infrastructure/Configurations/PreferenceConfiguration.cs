using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
{
    public void Configure(EntityTypeBuilder<Preference> builder)
    {
        builder.ToTable("Preferences");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
    }
}