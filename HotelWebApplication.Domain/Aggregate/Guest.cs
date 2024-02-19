using System;

namespace HotelWebApplication.Domain.Entities
{
    /// <summary>
    /// Описание сущности гостя
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
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
        /// Идентификатор комнаты проживания
        /// </summary>
        public int RoomId { get; set; }
        
        /// <summary>
        /// Комната проживания гостя
        /// </summary>
        public Room Room { get; set; }
    }
}