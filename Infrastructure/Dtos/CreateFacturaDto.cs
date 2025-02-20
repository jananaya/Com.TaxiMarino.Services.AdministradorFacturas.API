using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils.Constants;
using FluentValidation;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

public class CreateFacturaDto
{
    public string Cliente { get; set; } = default!;
    public string Fecha { get; set; } = default!;
}

public class CreateFacturaDtoValidator : AbstractValidator<CreateFacturaDto>
{
    public CreateFacturaDtoValidator()
    {
        RuleFor(f => f.Cliente)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmptyField)
            .WithName("Cliente");

        RuleFor(f => f.Fecha)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmptyField)
            .WithName("Fecha");
    }
}
