using HotelWebApplication.Application.Services;
using HotelWebApplication.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelWebApplication.Application.Extensions;

public static class ApplicationInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGuestService, GuestService>();
    }
}