using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils.Constants;
using FluentValidation;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

public class UpdateDetalleFacturaDto
{
    public string Producto { get; set; } = default!;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

public class UpdateDetalleFacturaDtoValidator : AbstractValidator<UpdateDetalleFacturaDto>
{
    public UpdateDetalleFacturaDtoValidator()
    {
        RuleFor(f => f.Producto)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmptyField)
            .WithName("Producto");

        RuleFor(f => f.Cantidad)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero)
            .WithName("Cantidad");

        RuleFor(f => f.PrecioUnitario)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero)
            .WithName("PrecioUnitario");
    }
}