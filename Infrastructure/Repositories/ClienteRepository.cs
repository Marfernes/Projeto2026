using Domain.Entidades;
using Domain.Interfaces;
using Domain.ValueObject;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> _clientes = new();

        public Task Adicionar(Cliente cliente)
        {
            _clientes.Add(cliente);
            return Task.CompletedTask;
        }

        public Task<Cliente?> BuscarPorId(Guid id)
        {
            return Task.FromResult(_clientes.FirstOrDefault(c => c.Id == id));
        }

        public Task<bool> ExisteCnpj(Cnpj cnpj)
        {
            return Task.FromResult(_clientes.Any(c => c.Cnpj.Equals(cnpj)));
        }
        public Task<Cliente?> ObterPorCnpj(string cnpj)
        {
            return Task.FromResult(_clientes.FirstOrDefault(c => c.Cnpj.Valor == cnpj));
        }

    }

}