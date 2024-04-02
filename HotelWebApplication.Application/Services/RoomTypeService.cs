using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Dto.Mappers;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Domain.Repositories;

namespace HotelWebApplication.Application.Services;

public class RoomTypeService(IRoomTypeRepository repository) : IRoomTypeService
{
    public async Task<ICollection<RoomTypeDto>> GetAllAsync()
    {
        var aggregate = await repository.GetAllAsync();
        return aggregate.Select(RoomTypeMapper.ToDto).ToList();
    }
}