namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Описание сущности комнаты
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Идентификатор типа комнаты
        /// </summary>
        public int RoomTypeId { get; set; }
    }
}