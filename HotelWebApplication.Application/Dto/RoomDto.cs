using HotelWebApplication.Common.Csv.Attributes;

namespace HotelWebApplication.Application.Dto;

public class RoomDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [CsvSerialize]
    public int Id { get; set; }
        
    /// <summary>
    /// Название комнаты
    /// </summary>
    [CsvSerialize]
    public string Name { get; set; }
        
    /// <summary>
    /// Количество гостей, которые могут быть заселены в номер
    /// </summary>
    [CsvSerialize]
    public int Capacity { get; set; }
        
    /// <summary>
    /// Идентификатор типа комнаты
    /// </summary>
    [CsvSerialize]
    public int RoomTypeId { get; set; }
        
    /// <summary>
    /// Тип комнаты
    /// </summary>
    [CsvSerialize]
    public RoomTypeDto RoomType { get; set; }
        
    /// <summary>
    /// Особенности комнаты
    /// </summary>
    public ICollection<PreferenceDto> Preferences { get; set; }
}