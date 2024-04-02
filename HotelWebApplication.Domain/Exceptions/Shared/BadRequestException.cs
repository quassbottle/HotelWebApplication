namespace HotelWebApplication.Domain.Exceptions.Shared;

public class BadRequestException(string message) : Exception(message);