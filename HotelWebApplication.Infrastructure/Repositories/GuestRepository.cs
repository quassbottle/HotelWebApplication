using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Exceptions.Guest;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Repositories;

public class GuestRepository(DataContext context) : IGuestRepository
{
    public async Task<Guest?> GetByIdAsync(int id)
    {
        var candidate = await context.Guests.FindAsync(id);
        return candidate;
    }

    public async Task DeleteByIdAsync(int id)
    {
        if (await context.Guests.FindAsync(id) is null)
        {
            throw new GuestNotFoundException("Guest with such id doesn't exist.");
        }

        context.Guests.Remove(new Guest { Id = id });
        
        await context.SaveChangesAsync();
    }

    public async Task<int> CreateAsync(Guest entity)
    {
        var entry = await context.Guests.AddAsync(entity);
        await context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task UpdateAsync(Guest entity, int id)
    {
        entity.Id = id;
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<Guest>> GetByRoomIdAsync(int roomId)
    {
        return await context.Guests.Where(guest => guest.RoomId == roomId).ToListAsync();
    }
}