using Domain.Entidades;
using Domain.Interfaces;
using Domain.Shared;
using Domain.ValueObject;

namespace Application.Commands.CriarCliente;

public class CriarClienteCommandHandler
{
    private readonly IClienteRepository _repository;

    public CriarClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(CriarClienteCommand command)
    {

        var cnpjResult = Cnpj.CriarCnpj(command.Cnpj);
        if (!cnpjResult.Sucesso)
            return Result<Guid>.Falha(cnpjResult.Erro!);


        var existe = await _repository.ExisteCnpj(cnpjResult.Valor!);
        if (existe)
            return Result<Guid>.Falha("Já existe um cliente cadastrado com este CNPJ.");

        var clienteResult = Cliente.CriarCliente(command.NomeFantasia, cnpjResult.Valor);
        if (!clienteResult.Sucesso)
            return Result<Guid>.Falha(clienteResult.Erro!);


        await _repository.Adicionar(clienteResult.Valor);

        return Result<Guid>.Ok(clienteResult.Valor.Id);
    }
}
