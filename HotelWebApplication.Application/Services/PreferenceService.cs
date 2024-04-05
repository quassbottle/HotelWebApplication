using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Dto.Mappers;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Domain.Repositories;

namespace HotelWebApplication.Application.Services;

public class PreferenceService(IPreferenceRepository repository) : IPreferenceService
{
    public async Task<ICollection<PreferenceDto>> GetAllAsync()
    {
        var aggregate = await repository.GetAllAsync();
        return aggregate.Select(PreferenceMapper.ToDto).ToList();
    }
}