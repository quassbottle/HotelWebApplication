using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Repositories;

public class PreferenceRepository(DataContext context) : IPreferenceRepository
{
    public async Task<PreferenceAggregate?> GetByIdAsync(int id)
    {
        var candidate = await context.Preferences.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        return candidate;
    }

    public async Task<ICollection<PreferenceAggregate>> GetAllAsync()
    {
        return await context.Preferences.ToListAsync();
    }
}