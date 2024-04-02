using HotelWebApplication.Domain.Exceptions.Shared;

namespace HotelWebApplication.Domain.Exceptions.Guest;

public class GuestNotFoundException(string message) : NotFoundException(message);