using Application.Commands.CriarCliente;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Application.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton< IClienteRepository ,ClienteRepository>();
builder.Services.AddTransient<CriarClienteCommandHandler>();
builder.Services.AddTransient<BuscarClientePorIdHandler>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
