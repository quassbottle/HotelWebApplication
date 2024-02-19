using HotelWebApplication.Domain.Exceptions.Shared;

namespace HotelWebApplication.Domain.Exceptions.Guest;

public class GuestNotFoundException : NotFoundException
{
    public GuestNotFoundException(string message) : base(message)
    {
    }
}