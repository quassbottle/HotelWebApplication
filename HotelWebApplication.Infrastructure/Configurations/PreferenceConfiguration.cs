using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelWebApplication.Infrastructure.Configurations;

public class PreferenceConfiguration : IEntityTypeConfiguration<PreferenceAggregate>
{
    public void Configure(EntityTypeBuilder<PreferenceAggregate> builder)
    {
        builder.ToTable("Preferences");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
    }
}