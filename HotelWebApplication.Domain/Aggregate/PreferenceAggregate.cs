namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Описание сущности предпочтений гостей 
    /// </summary>
    public class PreferenceAggregate
    {
        /// <summary>
        /// Идентификатор предпочтения
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Предпочтение
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// Комнаты с данной особенностью
        /// </summary>
        public ICollection<RoomAggregate?> Rooms { get; set; }
    }
}