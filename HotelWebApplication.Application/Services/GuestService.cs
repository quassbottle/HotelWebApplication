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
    public async Task<int> CreateAsync(GuestDto guest)
    {
        if (!await roomRepository.ExistsByIdAsync(guest.RoomId))
        {
            throw new RoomNotFoundException("Room with such id doesn't exist.");
        }

        var room = await roomRepository.GetByIdAsync(guest.RoomId);

        if (room.Guests.Count + 1 > room.Capacity)
        {
            throw new RoomIsFullException(room.Id);
        }
        
        return await guestRepository.CreateAsync(guest.ToAggregate());
    }

    public async Task DeleteAsync(int guestId)
    {
        await guestRepository.DeleteByIdAsync(guestId);
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

    public async Task ClearAsync()
    {
        await guestRepository.ClearAsync();
    }

    public async Task UpdateAsync(int id, GuestDto dto)
    {
        var aggregate = await guestRepository.GetByIdAsync(id);

        if (aggregate is null)
        {
            throw new GuestNotFoundException("Guest with such id doesn't exist");
        }

        await guestRepository.UpdateAsync(dto.ToAggregate(), id);
    }

    public async Task<ICollection<GuestDto>> GetAllAsync()
    {
        var aggregate = await guestRepository.GetAllAsync();

        return aggregate.Select(GuestMapper.ToDto).ToList();
    }
}