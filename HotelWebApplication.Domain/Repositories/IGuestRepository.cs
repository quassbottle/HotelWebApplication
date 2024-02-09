using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для управления гостями 
    /// </summary>
    public interface IGuestRepository
    {
        /// <summary>
        /// Асинхронно получить гостя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор гостя</param>
        /// <returns>Гость, найденный по идентификатору. Возвращает null если гость не найден</returns>
        Task<Guest> GetByIdAsync(int id);
        
        /// <summary>
        /// Асинхронно удалить гостя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
        
        /// <summary>
        /// Асинхронно создать гостя
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Идентификатор созданного гостя</returns>
        Task<int> CreateAsync(Guest entity);
        
        /// <summary>
        /// Асинхронное обновить гостя по идентификатору
        /// </summary>
        /// <param name="entity">Параметры, которые будут обновлены у гостя</param>
        /// <param name="id">Идентификатор гостя</param>
        Task UpdateAsync(Guest entity, int id);
    }
}