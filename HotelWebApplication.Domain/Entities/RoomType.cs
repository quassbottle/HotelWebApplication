namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Сущность типа комнаты
    /// </summary>
    public class RoomType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название типа комнаты
        /// </summary>
        public string Name { get; set; }
    }
}