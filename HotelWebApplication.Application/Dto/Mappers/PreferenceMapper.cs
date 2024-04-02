using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Application.Dto.Mappers;

public static class PreferenceMapper
{
    public static PreferenceDto ToDto(this PreferenceAggregate aggregate)
    {
        return new PreferenceDto
        {
            Id = aggregate.Id,
            Value = aggregate.Value,
        };
    }
    
    public static PreferenceAggregate ToAggregate(this PreferenceDto dto)
    {
        return new PreferenceAggregate
        {
            Id = dto.Id,
            Value = dto.Value,
        };
    }
}