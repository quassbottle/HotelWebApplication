namespace HotelWebApplication.Models.Room;

public class RoomCreateRequest
{
    public string Name { get; set; }
    public int RoomTypeId { get; set; }
    public int Capacity { get; set; }
    public ICollection<int> Preferences { get; set; }
}