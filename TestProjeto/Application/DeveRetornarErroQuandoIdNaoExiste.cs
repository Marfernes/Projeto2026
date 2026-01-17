using Application.Queries;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjeto.Application
{
    public class DeveRetornarErroQuandoIdNaoExiste
    {
        [Fact]
        public async Task DeveRetornarErroIdNaoExiste()
        {
            var repository = new ClienteRepository();
            var handler = new BuscarClientePorIdHandler(repository);

            var resultado = await handler.Handle(new BuscarClientePorIdQuery(Guid.NewGuid()));

            Assert.False(resultado.Sucesso);
            Assert.Equal("Cliente não encontrado.", resultado.Erro);
        }

    }
}
