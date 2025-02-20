using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils.Constants;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers;

public class DetallesFacturaManager : IDetallesFacturaManager
{
    private readonly IDetallesFacturaRepository _detallesFacturaRepository;
    private readonly IFacturasRepository _facturasRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DetallesFacturaManager(IDetallesFacturaRepository detallesFacturaRepository, IFacturasRepository facturasRepository, IUnitOfWork unitOfWork)
    {
        _detallesFacturaRepository = detallesFacturaRepository;
        _facturasRepository = facturasRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyCollection<DetalleFacturaDto>> GetDetallesFacturaByFacturaIdAsync(int facturaId)
    {
        var detallesFactura = await _detallesFacturaRepository.GetDetallesFacturaByFacturaIdAsync(facturaId);
        return detallesFactura.Select(MapDetalleFacturaToDto).ToList();
    }

    public async Task<DetalleFacturaDto> CreateDetalleFacturaAsync(CreateDetalleFacturaDto createDetalleFacturaDto)
    {
        var factura = await _facturasRepository.GetAsync(createDetalleFacturaDto.FacturaId);

        if (factura is null)
        {
            throw new KeyNotFoundException(ValidationMessages.FacturaNotFound);
        }

        var detalleFactura = new DetalleFactura
        {
            FacturaId = createDetalleFacturaDto.FacturaId,
            Producto = createDetalleFacturaDto.Producto,
            Cantidad = createDetalleFacturaDto.Cantidad,
            PrecioUnitario = createDetalleFacturaDto.PrecioUnitario,
            Subtotal = createDetalleFacturaDto.Cantidad * createDetalleFacturaDto.PrecioUnitario
        };

        _detallesFacturaRepository.Add(detalleFactura);

        factura.Total += detalleFactura.Subtotal;

        await _unitOfWork.SaveAsync();

        return MapDetalleFacturaToDto(detalleFactura);
    }

    public async Task DeleteDetalleFacturaAsync(int id)
    {
        var detalleFactura = await _detallesFacturaRepository.GetAsync(id);

        if (detalleFactura is null)
        {
            throw new KeyNotFoundException(ValidationMessages.DetalleFacturaNotFound);
        }

        var factura = detalleFactura.Factura;
        factura.Total -= detalleFactura.Subtotal;

        _facturasRepository.Update(factura);
        _detallesFacturaRepository.Remove(detalleFactura);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateDetalleFacturaAsync(int id, UpdateDetalleFacturaDto updateDetalleFacturaDto)
    {
        var detalleFactura = await _detallesFacturaRepository.GetAsync(id);

        if (detalleFactura is null)
        {
            throw new KeyNotFoundException(ValidationMessages.DetalleFacturaNotFound);
        }
        var factura = detalleFactura.Factura;

        factura.Total -= detalleFactura.Subtotal;

        detalleFactura.Producto = updateDetalleFacturaDto.Producto;
        detalleFactura.Cantidad = updateDetalleFacturaDto.Cantidad;
        detalleFactura.PrecioUnitario = updateDetalleFacturaDto.PrecioUnitario;
        detalleFactura.Subtotal = updateDetalleFacturaDto.Cantidad * updateDetalleFacturaDto.PrecioUnitario;

        factura.Total += detalleFactura.Subtotal;

        _facturasRepository.Update(factura);
        _detallesFacturaRepository.Update(detalleFactura);
        await _unitOfWork.SaveAsync();
    }

    private static DetalleFacturaDto MapDetalleFacturaToDto(DetalleFactura detalleFactura)
    {
        return new DetalleFacturaDto
        {
            Id = detalleFactura.Id,
            FacturaId = detalleFactura.FacturaId,
            Producto = detalleFactura.Producto,
            Cantidad = detalleFactura.Cantidad,
            PrecioUnitario = detalleFactura.PrecioUnitario,
            Subtotal = detalleFactura.Subtotal
        };
    }
}