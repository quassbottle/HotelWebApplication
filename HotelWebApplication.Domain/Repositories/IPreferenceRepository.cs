using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Domain.Repositories;

public interface IPreferenceRepository
{
    Task<ICollection<PreferenceAggregate>> GetAllAsync();
    Task<PreferenceAggregate?> GetByIdAsync(int id);
}