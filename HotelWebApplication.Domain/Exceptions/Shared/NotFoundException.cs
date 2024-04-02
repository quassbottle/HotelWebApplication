namespace HotelWebApplication.Domain.Exceptions.Shared;

public class NotFoundException(string message) : Exception(message);