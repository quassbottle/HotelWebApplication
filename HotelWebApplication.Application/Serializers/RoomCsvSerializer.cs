using System.Text;
using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Serializers.Interfaces;
using HotelWebApplication.Common.Csv;

namespace HotelWebApplication.Application.Serializers;

public class RoomCsvSerializer : IRoomCsvSerializer
{
    public async Task<byte[]> SaveCsv(ICollection<RoomDto> rooms)
    {
        var serializer = new CsvExporter<RoomDto>();

        var result = await serializer.SaveAsync(rooms);

        return Encoding.UTF8.GetBytes(String.Join("\r\n", result));
    }
}