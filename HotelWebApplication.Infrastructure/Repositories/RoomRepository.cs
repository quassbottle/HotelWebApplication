using System.Linq.Expressions;
using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Exceptions.Room;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Repositories;

public class RoomRepository(DataContext context) : IRoomRepository
{
    public async Task<RoomAggregate?> GetByIdAsync(int id)
    {
        var candidate = await context.Rooms
            .Include(r => r.Preferences)
            .Include(r => r.Guests)
            .Include(r => r.RoomTypeAggregate)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
        return candidate;
    }

    public async Task DeleteByIdAsync(int id)
    {
        if (await context.Rooms.FindAsync(id) is null)
        {
            throw new RoomNotFoundException("Room with such id doesn't exist.");
        }

        context.Rooms.Remove(new RoomAggregate { Id = id });
        
        await context.SaveChangesAsync();
    }

    public async Task<int> CreateAsync(RoomAggregate entity)
    {
        var preferenceIds = entity.Preferences.Select(p => p.Id);
        var matchingPreferences = await context.Preferences
            .Where(p => preferenceIds.Contains(p.Id))
            .ToListAsync();
        
        entity.Preferences = matchingPreferences;

        var entry = await context.Rooms.AddAsync(entity);
        await context.SaveChangesAsync();
    
        return entry.Entity.Id;
    }

    public async Task UpdateAsync(RoomAggregate entity, int id)
    {
        entity.Id = id;
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await context.Rooms.FindAsync(id) is not null;
    }

    public async Task<ICollection<RoomAggregate>> GetAllAsync()
    {
        return await context.Rooms
            .Include(r => r.Preferences)
            .Include(r => r.Guests)
            .Include(r => r.RoomTypeAggregate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<RoomAggregate>> GetByPreferencesAsync(ICollection<PreferenceAggregate> preferences)
    {
        return await context.Rooms
            .Include(r => r.Preferences)
            .AsNoTracking()
            .Where(r => r.Preferences.Select(p => p.Id).All(preferences.Select(g => g.Id).Contains))
            .ToListAsync();
    }

    public async Task<ICollection<RoomAggregate>> WhereAsync(Expression<Func<RoomAggregate, bool>> predicate)
    {
        return await context.Rooms
            .Include(r => r.Preferences)
            .Include(r => r.Guests)
            .Include(r => r.RoomTypeAggregate)
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }

    public Task<ICollection<RoomAggregate>> SelectAsync<TResult>(Expression<Func<RoomAggregate, TResult>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<RoomAggregate>> SelectAsync(Expression<Func<RoomAggregate, RoomAggregate>> predicate)
    {
        return await context.Rooms
            .Include(r => r.Preferences)
            .Include(r => r.Guests)
            .Include(r => r.RoomTypeAggregate)
            .AsNoTracking()
            .Select(predicate)
            .ToListAsync();
    }
}