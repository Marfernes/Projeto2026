using Application.Shared;

namespace Domain.ValueObject
{
    public sealed class Cnpj
    {
        public string Valor { get; }
        public Cnpj(string valor) 
        {
            Valor = valor;
        }
        public static Result<Cnpj> CriarCnpj(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return Result<Cnpj>.Falha("CNPJ é obrigatório");

            valor = valor
                .Replace(".", "")
                .Replace("/", "")
                .Replace("-", "");

            if (valor.Length != 14)
                return Result<Cnpj>.Falha("CNPJ deve conter 14 dígitos.");

            if (!valor.All(char.IsDigit))
                return Result<Cnpj>.Falha("CNPJ deve conter apenas números.");

            return Result<Cnpj>.Ok(new Cnpj(valor));

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
