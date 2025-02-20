using Microsoft.AspNetCore.Mvc;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Controllers;

[Route("")]
public class HomeController : BaseController
{
    [HttpGet]
    public IActionResult Get() => Ok("Com.TaxiMarino.Services.AdministradorFacturas.API is running.");
}