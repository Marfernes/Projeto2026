namespace Application.Commands.CriarCliente;

public record CriarClienteCommand(
     string NomeFantasia,
     string Cnpj
);