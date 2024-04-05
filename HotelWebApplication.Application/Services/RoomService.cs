using System.Linq.Expressions;
using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Dto.Mappers;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Domain.Entities;
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

    public async Task<ICollection<RoomDto>> GetByPreferencesAsync(ICollection<int> preference)
    {
        var all = await repository.GetAllAsync();

        /*var match = all
            .Where(r => r.Preferences.Select(p => p.Id).All(preference.Conta9ins));*/

        var match = all.Where(r => preference.All(w => r.Preferences.Select(p => p.Id).Contains(w)));
        
        return match.Select(RoomMapper.ToDto).ToList();
    }

    public async Task<int> CreateAsync(RoomDto dto)
    {
        var id = await repository.CreateAsync(dto.ToAggregate());

        return id;
    }
}