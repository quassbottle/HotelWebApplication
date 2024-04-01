using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Application.Dto.Mappers;

public static class GuestMapper
{
    public static GuestDto ToDto(this GuestAggregate aggregate)
    {
        return new GuestDto
        {
            Id = aggregate.Id,
            RoomId = aggregate.RoomId,
            Patronymic = aggregate.Patronymic,
            Birthdate = aggregate.Birthdate,
            Name = aggregate.Name,
            Surname = aggregate.Surname,
        };
    }

    public static GuestAggregate ToAggregate(this GuestDto dto)
    {
        return new GuestAggregate
        {
            Id = dto.Id,
            Name = dto.Name,
            Surname = dto.Surname,
            Patronymic = dto.Patronymic,
            Birthdate = dto.Birthdate,
            RoomId = dto.RoomId,
        };
    }
}