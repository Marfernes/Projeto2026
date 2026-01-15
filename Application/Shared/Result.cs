namespace Application.Shared
{
    public class Result<T>
    {
        public bool Sucesso { get; }
        public T? Valor { get; }
        public string? Erro { get; }

        private Result(bool sucesso, T? valor, string? erro)
        {
            Sucesso = sucesso;
            Valor = valor;
            Erro = erro;
        }

        public static Result<T> Ok(T valor)
            => new Result<T>(true, valor, null);

        public static Result<T> Falha(string erro)
            => new Result<T>(false, default, erro);
    }
    
}
