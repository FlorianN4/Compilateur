namespace Compilateur.Exception
{
    public class ValueOverflowException : System.Exception
    {
        public ValueOverflowException()
        {
        }

        public ValueOverflowException(string message)
            : base(message)
        {
        }

        public ValueOverflowException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
