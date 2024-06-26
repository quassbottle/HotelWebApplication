namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Сущность типа комнаты
    /// </summary>
    public class RoomTypeAggregate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название типа комнаты
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Комнаты данного типа
        /// </summary>
        public ICollection<RoomAggregate> Rooms { get; set; }
    }
}