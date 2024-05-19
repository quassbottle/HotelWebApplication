using System.Text;
using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Serializers.Interfaces;
using HotelWebApplication.Common.Csv;

namespace HotelWebApplication.Application.Serializers;

public class GuestCsvSerializer : IGuestCsvSerializer
{
    public async Task<byte[]> SaveCsv(ICollection<GuestDto> guests)
    {
        var serializer = new CsvExporter<GuestDto>();

        var result = await serializer.SaveAsync(guests);

        return Encoding.UTF8.GetBytes(String.Join("\r\n", result));
    }
}