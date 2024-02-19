using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers.Shared;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiV1Controller : ControllerBase
{
}