using System.Runtime.Serialization;

namespace PPOIS3.Exceptions
{
    public class SuperItemException : Exception
    {
        public SuperItemException()
        {
        }

        public SuperItemException(string? message) : base(message)
        {
        }

        public SuperItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SuperItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
