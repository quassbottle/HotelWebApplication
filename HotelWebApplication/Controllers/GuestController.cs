using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Serializers.Interfaces;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Controllers.Shared;
using HotelWebApplication.Models.Guest;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers;

public class GuestController(IGuestService guestService, IGuestCsvSerializer guestCsvSerializer) : ApiV1Controller
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGuestById(int id)
    {
        return Ok(await guestService.GetByIdAsync(id));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuestById(int id)
    {
        await guestService.DeleteAsync(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterGuest(GuestCreateRequest request)
    {
        return Ok(await guestService.CreateAsync(new GuestDto
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Birthdate = request.Birthdate,
            RoomId = request.RoomId,
        }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGuest(int id, GuestUpdateRequest request)
    {
        await guestService.UpdateAsync(id, new GuestDto
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Birthdate = request.Birthdate,
            RoomId = request.RoomId,
        });
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DropGuests()
    {
        await guestService.ClearAsync();
        return Ok();
    }

    [HttpGet("Csv")]
    public async Task<IActionResult> GetCsv()
    {
        var guests = await guestService.GetAllAsync();

        return File(await guestCsvSerializer.SaveCsv(guests), "text/csv", $"Guests {DateTime.Now}.csv");
    }
}