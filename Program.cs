using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.DisableBuiltInModelValidation = true;
});
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();