using HotelWebApplication.Application.Services.Interfaces;
using HotelWebApplication.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers;

public class PreferenceController(IPreferenceService preferenceService) : ApiV1Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await preferenceService.GetAllAsync());
    }
}