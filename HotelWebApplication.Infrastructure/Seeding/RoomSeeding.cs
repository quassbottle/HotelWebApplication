using HotelWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Seeding;

public static class RoomSeeding
{
    public static void AddRooms(this ModelBuilder builder)
    {
        builder.Entity<RoomAggregate>().HasData(
            new RoomAggregate
            {
                Id = 1, Name = "Эконом на одного", Capacity = 1, RoomTypeId = 1, Preferences = new[]
                {
                    new PreferenceAggregate { Id = 1 },
                    new PreferenceAggregate { Id = 3 },
                    new PreferenceAggregate { Id = 8 }
                }
            },
            new RoomAggregate
            {
                Id = 2, Name = "Эконом на двоих", Capacity = 1, RoomTypeId = 1, Preferences = new[]
                {
                    new PreferenceAggregate { Id = 1 },
                    new PreferenceAggregate { Id = 3 },
                    new PreferenceAggregate { Id = 8 }
                }
            },
            new RoomAggregate
            {
                Id = 3, Name = "Стандарт", Capacity = 2, RoomTypeId = 1, Preferences = new[]
                {
                    new PreferenceAggregate { Id = 1 },
                    new PreferenceAggregate { Id = 3 },
                    new PreferenceAggregate { Id = 8 }
                }
            }
        );
    }
}