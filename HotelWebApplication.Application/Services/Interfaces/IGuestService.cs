using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IGuestService
{
    Task<int> CreateAsync(GuestDto guest);
    Task DeleteAsync(int guestId);
    Task<GuestDto> GetByIdAsync(int id);
    Task<ICollection<GuestDto>> GetByRoomIdAsync(int roomId);
    Task ClearAsync();
    Task UpdateAsync(int id, GuestDto dto);
    Task<ICollection<GuestDto>> GetAllAsync();
}