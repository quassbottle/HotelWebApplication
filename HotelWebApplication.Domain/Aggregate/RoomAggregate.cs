namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Описание сущности комнаты
    /// </summary>
    public class RoomAggregate
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
        /// Количество гостей, которые могут быть заселены в номер
        /// </summary>
        public int Capacity { get; set; }
        
        /// <summary>
        /// Идентификатор типа комнаты
        /// </summary>
        public int RoomTypeId { get; set; }
        
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public RoomTypeAggregate RoomTypeAggregate { get; set; }
        
        /// <summary>
        /// Особенности комнаты
        /// </summary>
        public ICollection<PreferenceAggregate> Preferences { get; set; }
        
        /// <summary>
        /// Жильцы комнаты
        /// </summary>
        public ICollection<GuestAggregate> Guests { get; set; }
    }
}