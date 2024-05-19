using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Serializers.Interfaces;

public interface IGuestCsvSerializer
{
    Task<byte[]> SaveCsv(ICollection<GuestDto> guests);
}