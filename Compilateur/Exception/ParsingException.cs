namespace Compilateur.Exception
{
    public class ParsingException : System.Exception
    {
        public ParsingException()
        {
        }

        public ParsingException(string message)
            : base(message)
        {
        }

        public ParsingException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
