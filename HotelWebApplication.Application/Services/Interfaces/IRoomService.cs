using System.Linq.Expressions;
using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IRoomService
{
    Task<RoomDto> GetByIdAsync(int id);
    Task<ICollection<RoomDto>> GetByPreferencesAsync(ICollection<int> preference);
    Task<int> CreateAsync(RoomDto dto);
}