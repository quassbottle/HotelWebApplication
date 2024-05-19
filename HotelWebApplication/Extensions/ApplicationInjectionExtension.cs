using HotelWebApplication.Application.Serializers;
using HotelWebApplication.Application.Serializers.Interfaces;
using HotelWebApplication.Application.Services;
using HotelWebApplication.Application.Services.Interfaces;

namespace HotelWebApplication.Extensions;

public static class ApplicationInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IGuestCsvSerializer, GuestCsvSerializer>();
        services.AddSingleton<IRoomCsvSerializer, RoomCsvSerializer>();

        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
    }
}