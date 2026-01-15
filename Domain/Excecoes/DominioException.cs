
namespace Domain.Excecoes
{
    public class DominioException : Exception
    {
        public DominioException(string mensagem) 
            : base(mensagem) { }
    }
}
