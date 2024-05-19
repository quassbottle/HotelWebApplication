using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Serializers.Interfaces;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Controllers.Shared;
using HotelWebApplication.Models.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers;

public class RoomController(IGuestService guestService, IRoomService roomService, IRoomCsvSerializer roomCsvSerializer) : ApiV1Controller
{
    [HttpGet("{id}/Guests")]
    public async Task<IActionResult> GetGuestsOfRoom(int id)
    {
        return Ok(await guestService.GetByRoomIdAsync(id));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await roomService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoomCreateRequest request)
    {
        return Ok(await roomService.CreateAsync(new RoomDto
        {
            RoomTypeId = request.RoomTypeId,
            Capacity = request.Capacity,
            Name = request.Name,
            Preferences = request.Preferences.Select(preferenceId => new PreferenceDto { Id = preferenceId }).ToList()
        }));
    }
    
    [HttpGet]
    public async Task<IActionResult> Filter([FromQuery] ICollection<int> preference, [FromQuery] ICollection<int> roomType)
    {
        return Ok(await roomService.FilterAsync(roomType, preference));
    }

    [HttpDelete]
    public async Task<IActionResult> Drop()
    {
        await roomService.ClearAsync();
        return Ok();
    }
    
    [HttpGet("Csv")]
    public async Task<IActionResult> GetCsv()
    {
        var rooms = await roomService.GetAllAsync();

        return File(await roomCsvSerializer.SaveCsv(rooms), "text/csv", $"Rooms {DateTime.Now}.csv");
    }
}