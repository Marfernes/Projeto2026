using Application.Commands.CriarCliente;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly CriarClienteCommandHandler _criarHandler;
        private readonly BuscarClientePorIdHandler _obterHandler;

        public ClientesController(CriarClienteCommandHandler criarHandler,
                              BuscarClientePorIdHandler obterHandler)
        {
            _criarHandler = criarHandler;
            _obterHandler = obterHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteCommand command)
        {
            var resultado = await _criarHandler.Handle(command);

            if (!resultado.Sucesso) 
                return BadRequest(resultado.Erro); 

            return Ok(resultado.Valor);
        }



        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var resultado = await _obterHandler.Handle(new BuscarClientePorIdQuery(id));

            if (!resultado.Sucesso || resultado.Valor == null) 
                return NotFound(resultado.Erro ?? "Cliente não encontrado");

            return Ok(resultado.Valor);
        }
    }
}
