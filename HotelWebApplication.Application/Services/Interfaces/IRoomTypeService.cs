using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IRoomTypeService
{
    Task<ICollection<RoomTypeDto>> GetAllAsync();
}