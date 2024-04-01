using HotelWebApplication.Domain.Entities;
using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Infrastructure.Repositories;

public class RoomTypeRepository(DataContext context) : IRoomTypeRepository
{
    public async Task<RoomTypeAggregate?> GetByIdAsync(int id)
    {
        var candidate = await context.RoomTypes.FindAsync(id);
        return candidate;
    }

    public async Task<ICollection<RoomTypeAggregate>> GetAllAsync()
    {
        return await context.RoomTypes.ToListAsync();
    }
}