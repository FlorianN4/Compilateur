namespace Compilateur.Exception
{
    public class SymbolAlreadyDefinedException : System.Exception
    {
        public SymbolAlreadyDefinedException()
        {
        }

        public SymbolAlreadyDefinedException(string message)
            : base(message)
        {
        }

        public SymbolAlreadyDefinedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
