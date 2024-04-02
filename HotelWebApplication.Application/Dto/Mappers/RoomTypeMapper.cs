using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Application.Dto.Mappers;

public static class RoomTypeMapper
{
    public static RoomTypeDto ToDto(this RoomTypeAggregate aggregate)
    {
        return new RoomTypeDto
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
        };
    }
}