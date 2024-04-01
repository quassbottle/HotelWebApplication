using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Exceptions.Room;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;

namespace HotelWebApplication.Infrastructure.Repositories;

public class RoomRepository(DataContext context) : IRoomRepository
{
    public async Task<RoomAggregate?> GetByIdAsync(int id)
    {
        var candidate = await context.Rooms.FindAsync(id);
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
}