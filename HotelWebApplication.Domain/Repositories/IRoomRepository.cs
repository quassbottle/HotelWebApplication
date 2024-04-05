using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для управления комнатами
    /// </summary>
    public interface IRoomRepository
    {
        /// <summary>
        /// Асинхронно получить комнаты по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор комнаты</param>
        /// <returns>Комната, найденная по идентификатору. Возвращает null если комната не найдена</returns>
        Task<RoomAggregate?> GetByIdAsync(int id);
        
        /// <summary>
        /// Асинхронно удалить комнату по идентификатору
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
        
        /// <summary>
        /// Асинхронно создать комнату
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Идентификатор созданного комнаты</returns>
        Task<int> CreateAsync(RoomAggregate entity);
        
        /// <summary>
        /// Асинхронное обновить комнату по идентификатору
        /// </summary>
        /// <param name="entity">Параметры, которые будут обновлены у комнаты</param>
        /// <param name="id">Идентификатор комнаты</param>
        Task UpdateAsync(RoomAggregate entity, int id);

        /// <summary>
        /// Асинхронно проверить, существует ли комната с указанным идентификатором
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Существует ли комната с указанным идентификатором</returns>
        Task<bool> ExistsByIdAsync(int id);

        Task<ICollection<RoomAggregate>> GetAllAsync();

        Task<ICollection<RoomAggregate>> GetByPreferencesAsync(ICollection<PreferenceAggregate> preferences);

        Task<ICollection<RoomAggregate>> WhereAsync(Expression<Func<RoomAggregate, bool>> predicate);
        
        Task<ICollection<RoomAggregate>> SelectAsync<TResult>(Expression<Func<RoomAggregate, TResult>> predicate);
    }
}