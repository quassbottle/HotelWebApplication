using HotelWebApplication.Domain.Repositories;
using HotelWebApplication.Infrastructure.Context;
using HotelWebApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.Extensions;

public static class InfrastructureInjectionExtensions
{
    public static void MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetService<DataContext>();
        context.Database.Migrate();
    }
    
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IPreferenceRepository, PreferenceRepository>();
    }
}