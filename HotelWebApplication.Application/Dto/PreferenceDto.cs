using System.Text.Json.Serialization;

namespace HotelWebApplication.Application.Dto;

public class PreferenceDto
{
    /// <summary>
    /// Идентификатор предпочтения
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Предпочтение
    /// </summary>
    public string Value { get; set; }
}