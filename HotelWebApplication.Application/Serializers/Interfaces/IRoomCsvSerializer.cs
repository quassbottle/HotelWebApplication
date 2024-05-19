using HotelWebApplication.Application.Dto;

namespace HotelWebApplication.Application.Serializers.Interfaces;

public interface IRoomCsvSerializer
{
    Task<byte[]> SaveCsv(ICollection<RoomDto> rooms);
}