using Application.Commands.CriarCliente;
using Application.Queries;
using Domain.Interfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ?? Injeção de dependência
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<CriarClienteCommandHandler>();
builder.Services.AddTransient<BuscarClientePorIdHandler>();

// ?? Controllers
builder.Services.AddControllers();

// ?? Swagger (OBRIGATÓRIO)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ?? Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Clientes v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
