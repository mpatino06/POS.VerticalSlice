using Microsoft.EntityFrameworkCore;
using POS.VerticalSlice.Exceptions;
using POS.VerticalSlice.Features.Product;
using POS.VerticalSlice.Infrastructure;
using Scalar.AspNetCore;

//Scalar.AspNetCore es un paquete NuGet de código abierto que proporciona una interfaz visual moderna e interactiva para documentar
//y probar APIs basadas en documentos OpenAPI en ASP.NET Core (funciona de forma nativa desde .NET 8, .NET 9 y .NET 10 en reemplazo de Swagger UI)

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("POSContext");
builder.Services.AddDbContext<POSContext>(options =>
    options.UseSqlServer(connectionString));

// Add global exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandle>();

//Add
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map the Scalar API reference endpoint
app.MapScalarApiReference();

app.MapControllers();

// Map Endpoints 
app.MapProductEndpoints();

app.Run();
