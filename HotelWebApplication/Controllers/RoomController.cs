using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers;

public class RoomController(IGuestService guestService) : ApiV1Controller
{
    [HttpGet("{id}/Guests")]
    public async Task<IActionResult> GetGuestsOfRoom(int id)
    {
        return Ok(await guestService.GetByRoomIdAsync(id));
    }
}