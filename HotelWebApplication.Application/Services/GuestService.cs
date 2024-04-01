using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Dto.Mappers;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Exceptions.Guest;
using HotelWebApplication.Domain.Exceptions.Room;
using HotelWebApplication.Domain.Repositories;

namespace HotelWebApplication.Application.Services;

public class GuestService(IGuestRepository guestRepository, IRoomRepository roomRepository) : IGuestService
{
    public async Task<int> RegisterAsync(GuestDto guest)
    {
        if (!await roomRepository.ExistsByIdAsync(guest.RoomId))
        {
            throw new RoomNotFoundException("Room with such id doesn't exist.");
        }
        
        return await guestRepository.CreateAsync(guest.ToAggregate());
    }

    public async Task<GuestDto> GetByIdAsync(int id)
    {
        var aggregate = await guestRepository.GetByIdAsync(id);

        if (aggregate is null)
        {
            throw new GuestNotFoundException("Guest with such id doesn't exist");
        }

        return aggregate.ToDto();
    }

    public async Task<ICollection<GuestDto>> GetByRoomIdAsync(int roomId)
    {
        if (!await roomRepository.ExistsByIdAsync(roomId))
        {
            throw new RoomNotFoundException("Room with such id doesn't exist.");
        }

        var aggregate = await guestRepository.GetByRoomIdAsync(roomId);

        return aggregate.Select(GuestMapper.ToDto).ToList();
    }
}