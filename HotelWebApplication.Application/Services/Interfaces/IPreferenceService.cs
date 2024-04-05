using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Services.Interfaces;

public interface IPreferenceService
{
    Task<ICollection<PreferenceDto>> GetAllAsync();
}