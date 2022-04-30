namespace Compilateur.Exception
{
    public class NotFoundSymbolException : System.Exception
    {
        public NotFoundSymbolException()
        {
        }

        public NotFoundSymbolException(string message)
            : base(message)
        {
        }

        public NotFoundSymbolException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
