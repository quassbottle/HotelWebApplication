namespace HotelWebApplication.Domain.Exceptions.Shared;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}