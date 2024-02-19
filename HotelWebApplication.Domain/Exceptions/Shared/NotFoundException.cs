namespace HotelWebApplication.Domain.Exceptions.Shared;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}