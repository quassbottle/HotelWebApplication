using HotelWebApplication.Application.Services;
using HotelWebApplication.Application.Services.Interfaces;

namespace HotelWebApplication.Extensions;

public static class ApplicationInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();
    }
}