using System.Linq.Expressions;
using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IRoomService
{
    Task<RoomDto> GetByIdAsync(int id);
    Task<ICollection<RoomDto>> MatchByPreferencesAsync(ICollection<int> preference);
    Task<ICollection<RoomDto>> MatchByRoomTypeAsync(ICollection<int> roomType);
    Task<ICollection<RoomDto>> FilterAsync(ICollection<int> roomType, ICollection<int> preference);
    Task<int> CreateAsync(RoomDto dto);
}