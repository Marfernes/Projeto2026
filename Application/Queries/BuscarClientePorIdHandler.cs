using Domain.Entidades;
using Domain.Interfaces;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Queries
{
    public class BuscarClientePorIdHandler
    {
        private readonly IClienteRepository _repository;

        public BuscarClientePorIdHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Cliente>> Handle(ObterClientePorIdQuery query)
        {
            var cliente = await _repository.BuscarPorId(query.Id);
            if (cliente is null)
                return Result<Cliente>.Falha("Cliente não encontrado.");

            return Result<Cliente>.Ok(cliente);
        }
    }
}
