using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Dto.Mappers;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Domain.Exceptions.Room;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Repositories;

namespace HotelWebApplication.Application.Services;

public class RoomService(IRoomRepository repository) : IRoomService
{
    public async Task<RoomDto> GetByIdAsync(int id)
    {
        var aggregate = await repository.GetByIdAsync(id);

        if (aggregate is null)
        {
            throw new RoomNotFoundException("Room with such id doesn't exist");
        }

        return aggregate.ToDto();
    }

    public async Task<int> CreateAsync(RoomDto dto)
    {
        var id = await repository.CreateAsync(dto.ToAggregate());

        return id;
    }
}