using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Seeding;

public static class RoomTypeSeeding
{
    public static void AddRoomTypes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomTypeAggregate>().HasData(
            new() { Id = 1, Name = "Эконом"},
            new() { Id = 2, Name = "Стандарт"},
            new() { Id = 3, Name = "Люкс"},
            new() { Id = 4, Name = "Президент"}
        );
    }
}