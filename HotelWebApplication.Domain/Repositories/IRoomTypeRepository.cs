using System.Threading.Tasks;
using HotelWebApplication.Domain.Entities;

namespace HotelWebApplication.Domain.Repositories
{
    public interface IRoomTypeRepository
    {
        /// <summary>
        /// Асинхронно получить тип комнаты по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа комнаты</param>
        /// <returns></returns>
        Task<RoomType> GetByIdAsync(int id);
    }
}