using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Seeding;

public static class PreferenceSeeding
{
    public static void AddPreferences(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PreferenceAggregate>().HasData(
            new() { Id = 1, Value = "Бесплатный интернет" },
            new() { Id = 2, Value = "Кондиционер" },
            new() { Id = 3, Value = "Ванная комната в номере" },
            new() { Id = 4, Value = "Кухня" },
            new() { Id = 5, Value = "Балкон" },
            new() { Id = 6, Value = "Общая ванная комната" },
            new() { Id = 7, Value = "Мини бар" },
            new() { Id = 8, Value = "Телевизор" },
            new() { Id = 9, Value = "Общая ванная комната" }
        );
    }
}