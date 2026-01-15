using Domain.Shared;
using Domain.ValueObject;

namespace Domain.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public bool Ativo { get; private set; }

        private Cliente (string nomeFantasia, Cnpj cnpj) 
        {
            Id = Guid.NewGuid();
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Ativo = true;
        }
        public static Result<Cliente> CriarCliente(string nomeFantasia, Cnpj cnpj)
        {
            if(string.IsNullOrWhiteSpace(nomeFantasia))
                return Result<Cliente>.Falha("Nome fantasia é obrigatório.");

           
            return Result<Cliente>.Ok(new Cliente(nomeFantasia, cnpj));
        }
        public void Desativar()
        {
            Ativo = false;
        }
    }
}
