using Domain.ValueObject;

namespace Domain.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public bool Ativo { get; private set; }
    }
}
