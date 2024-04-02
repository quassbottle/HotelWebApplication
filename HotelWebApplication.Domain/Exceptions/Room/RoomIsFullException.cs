using HotelWebApplication.Domain.Exceptions.Shared;

namespace HotelWebApplication.Domain.Exceptions.Room;

public class RoomIsFullException(int id) : BadRequestException($"Room with id {id} is full");