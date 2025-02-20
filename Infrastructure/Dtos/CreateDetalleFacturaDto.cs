using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils.Constants;
using FluentValidation;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

public class CreateDetalleFacturaDto : UpdateDetalleFacturaDto
{
    public int FacturaId { get; set; }
}

public class CreateDetalleFacturaDtoValidator : AbstractValidator<CreateDetalleFacturaDto>
{
    public CreateDetalleFacturaDtoValidator()
    {
        Include(new UpdateDetalleFacturaDtoValidator());

        RuleFor(f => f.FacturaId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero)
            .WithName("FacturaId");
    }
}