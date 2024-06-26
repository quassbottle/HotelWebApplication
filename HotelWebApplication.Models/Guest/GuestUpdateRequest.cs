namespace HotelWebApplication.Models.Guest;

/// <summary>
/// Запрос на обновление гостя
/// </summary>
public class GuestUpdateRequest
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
        
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }
        
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; }
        
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime Birthdate { get; set; }
    
    /// <summary>
    /// Идентификатор комнаты
    /// </summary>
    public int RoomId { get; set; }
}