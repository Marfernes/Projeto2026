using Domain.Entidades;
using Domain.ValueObject;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task<Cliente?> BuscarPorId(Guid id);
        Task<bool> ExisteCnpj(Cnpj cnpj);
    }
}
