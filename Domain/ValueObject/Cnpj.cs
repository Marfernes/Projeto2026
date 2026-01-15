
using Domain.Excecoes;

namespace Domain.ValueObject
{
    public sealed class Cnpj
    {
        public string Valor { get; }
        public Cnpj(string valor) 
        {
            Valor = valor;
        }
        public static Cnpj CriarCnpj(string valor)
        { 
            if(string.IsNullOrWhiteSpace(valor))
                throw new DominioException("CNPJ não pode ser vazio.");
            return new Cnpj(valor); 
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Cnpj)
                return false;

            var outroCnpj = (Cnpj)obj;

            return Valor == outroCnpj.Valor;
        }
        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }

    }
}
