using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IGuestService
{
    Task<int> RegisterAsync(GuestDto guest);
    Task<GuestDto> GetByIdAsync(int id);
    Task<ICollection<GuestDto>> GetByRoomIdAsync(int roomId);
}