using HotelWebApplication.Application.Dto;
using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Controllers.Shared;
using HotelWebApplication.Models.Guest;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers;

public class GuestController(IGuestService guestService) : ApiV1Controller
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGuestById(int id)
    {
        return Ok(await guestService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterGuest(GuestCreateRequest request)
    {
        return Ok(await guestService.RegisterAsync(new GuestDto
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Birthdate = request.Birthdate,
            RoomId = request.RoomId,
        }));
    } 
}