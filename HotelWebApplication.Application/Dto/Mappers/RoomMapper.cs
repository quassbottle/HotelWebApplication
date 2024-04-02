using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Application.Dto.Mappers;

public static class RoomMapper
{
    public static RoomDto ToDto(this RoomAggregate aggregate)
    {
        return new RoomDto
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
            RoomTypeId = aggregate.RoomTypeId,
            RoomType = aggregate.RoomTypeAggregate.ToDto(),
            Capacity = aggregate.Capacity,
            Preferences = aggregate.Preferences.Select(PreferenceMapper.ToDto).ToList()
        };
    }

    public static RoomAggregate ToAggregate(this RoomDto dto)
    {
        return new RoomAggregate
        {
            Id = dto.Id,
            Name = dto.Name,
            Capacity = dto.Capacity,
            RoomTypeId = dto.RoomTypeId,
            Preferences = dto.Preferences.Select(PreferenceMapper.ToAggregate).ToList(),
        };
    }
}