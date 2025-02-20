using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Controllers;

public class DetallesFacturaController : BaseController
{
    private readonly IDetallesFacturaManager _detallesFacturaManager;

    public DetallesFacturaController(IDetallesFacturaManager detallesFacturaManager)
    {
        _detallesFacturaManager = detallesFacturaManager;
    }

    [HttpGet("facturas/{facturaId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<DetalleFacturaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IReadOnlyCollection<DetalleFacturaDto>>> GetDetallesFacturaByFacturaIdAsync(int facturaId)
    {
        var detallesFactura = await _detallesFacturaManager.GetDetallesFacturaByFacturaIdAsync(facturaId);
        return Ok(detallesFactura);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DetalleFacturaDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DetalleFacturaDto>> CreateDetalleFacturaAsync([FromBody] CreateDetalleFacturaDto createDetalleFacturaDto)
    {
        var detalleFacturaDto = await _detallesFacturaManager.CreateDetalleFacturaAsync(createDetalleFacturaDto);
        return StatusCode(StatusCodes.Status201Created, detalleFacturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateDetalleFacturaAsync([FromRoute] int id, [FromBody] UpdateDetalleFacturaDto updateDetalleFacturaDto)
    {
        await _detallesFacturaManager.UpdateDetalleFacturaAsync(id, updateDetalleFacturaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteDetalleFacturaAsync([FromRoute] int id)
    {
        await _detallesFacturaManager.DeleteDetalleFacturaAsync(id);
        return NoContent();
    }
}