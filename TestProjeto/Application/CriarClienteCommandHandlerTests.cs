using Application.Commands.CriarCliente;
using Infrastructure.Repositories;

namespace TestProjeto.Application
{
    public class CriarClienteCommandHandlerTests
    {
        [Fact]
        public async Task DeveCriarClienteComSucesso()
        {
            var repo = new ClienteRepository();
            var handler = new CriarClienteCommandHandler(repo);

            var command = new CriarClienteCommand("Cliente Teste", "12345678910123");
            var resultado = await handler.Handle(command);

            Assert.True(resultado.Sucesso);
            Assert.NotEqual(Guid.Empty, resultado.Valor);
        }

    }
}

