using HotelWebApplication.Domain.Exceptions.Shared;

namespace HotelWebApplication.Domain.Exceptions.Room;

public class RoomNotFoundException : NotFoundException
{
    public RoomNotFoundException(string message) : base(message)
    {
    }
}