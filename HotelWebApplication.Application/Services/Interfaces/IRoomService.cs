using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IRoomService
{
    Task<RoomDto> GetByIdAsync(int id);
    Task<int> CreateAsync(RoomDto dto);
}