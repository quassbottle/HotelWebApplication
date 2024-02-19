using System.Text.Json.Serialization;

namespace HotelWebApplication.Application.Dto;

public class RoomTypeDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [JsonIgnore]
    public int Id { get; set; }
    
    /// <summary>
    /// Название типа комнаты
    /// </summary>
    public string Name { get; set; }
}