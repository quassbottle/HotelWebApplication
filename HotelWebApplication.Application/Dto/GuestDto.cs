using HotelWebApplication.Common.Csv.Attributes;

namespace HotelWebApplication.Application.Dto;

public class GuestDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [CsvSerialize]
    public int Id { get; set; }
        
    /// <summary>
    /// Имя
    /// </summary>
    [CsvSerialize]
    public string Name { get; set; }
        
    /// <summary>
    /// Фамилия
    /// </summary>
    [CsvSerialize]
    public string Surname { get; set; }
        
    /// <summary>
    /// Отчество
    /// </summary>
    [CsvSerialize]
    public string Patronymic { get; set; }
        
    /// <summary>
    /// Дата рождения
    /// </summary>
    [CsvSerialize]
    public DateTime Birthdate { get; set; }
    
    /// <summary>
    /// Идентификатор комнаты
    /// </summary>
    [CsvSerialize]
    public int RoomId { get; set; }
}