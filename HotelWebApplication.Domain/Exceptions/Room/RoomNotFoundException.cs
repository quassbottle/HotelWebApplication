using HotelWebApplication.Domain.Exceptions.Shared;

namespace HotelWebApplication.Domain.Exceptions.Room;

public class RoomNotFoundException(string message) : NotFoundException(message);