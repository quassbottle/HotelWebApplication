using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Exceptions.Guest;
using HotelWebApplication.Domain.Exceptions.Room;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Repositories;

public class GuestRepository(DataContext context) : IGuestRepository
{
    public async Task<GuestAggregate?> GetByIdAsync(int id)
    {
        var candidate = await context.Guests.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        return candidate;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var candidate = await context.Guests.FindAsync(id);
        if (candidate is null)
        {
            throw new GuestNotFoundException("Guest with such id doesn't exist.");
        }

        context.Guests.Remove(new GuestAggregate { Id = id });
        
        await context.SaveChangesAsync();
    }

    public async Task<int> CreateAsync(GuestAggregate entity)
    {
        var entry = await context.Guests.AddAsync(entity);
        await context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task UpdateAsync(GuestAggregate entity, int id)
    {
        context.Guests.Update(new GuestAggregate
        {
            Id = id,
            Birthdate = entity.Birthdate,
            Name = entity.Name,
            Patronymic = entity.Patronymic,
            Surname = entity.Surname,
            RoomId = entity.RoomId
        });
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<GuestAggregate>> GetByRoomIdAsync(int roomId)
    {
        return await context.Guests.Where(guest => guest.RoomId == roomId).ToListAsync();
    }

    public async Task<ICollection<GuestAggregate>> GetAllAsync()
    {
        return await context.Guests
            .Include(g => g.RoomAggregate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task ClearAsync()
    {
        await context.Database.ExecuteSqlAsync($"delete from \"Guests\"");
        await context.SaveChangesAsync();
    }
}