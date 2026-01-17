using Application.Queries;
using Domain.Entidades;
using Domain.ValueObject;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjeto.Application
{
    public class DeveRetornarClienteComSucessoQuandoIdExiste
    {
        [Fact]
        public async Task DeveRetornarClienteQuandoIdExiste()
        {  
            var repository = new ClienteRepository();
            var cliente = Cliente.CriarCliente(
                "Cliente Teste",
                Cnpj.CriarCnpj("12345678910123").Valor!
            ).Valor!;

            await repository.Adicionar(cliente);

            var handler = new BuscarClientePorIdHandler(repository);

            var resultado = await handler.Handle(new BuscarClientePorIdQuery(cliente.Id));

            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado.Valor);
            Assert.Equal(cliente.Id, resultado.Valor.Id);
        }
    }
}
