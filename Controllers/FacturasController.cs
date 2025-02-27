using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Controllers;

public class FacturasController : BaseController
{
    private readonly IFacturasManager _facturasManager;

    public FacturasController(IFacturasManager facturasManager)
    {
        _facturasManager = facturasManager;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<FacturaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetFacturasAsync()
    {
        return Ok(await _facturasManager.GetFacturasAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(FacturaDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFacturaAsync([FromBody] CreateFacturaDto createfacturaDto)
    {
        var facturaDto = await _facturasManager.CreateFacturaAsync(createfacturaDto);
        return StatusCode(StatusCodes.Status201Created, facturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateFacturaAsync([FromRoute] int id, [FromBody] CreateFacturaDto facturaDto)
    {
        await _facturasManager.UpdateFacturaAsync(id, facturaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFacturaAsync([FromRoute] int id)
    {
        await _facturasManager.DeleteFacturaAsync(id);
        return NoContent();
    }
}