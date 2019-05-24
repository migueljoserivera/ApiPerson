using System;
using System.Runtime.Serialization;

namespace ApiPerson.BusinessLogic.Exceptions
{
    [Serializable]
    public class InvalidMailAddressException : Exception
    {
        public InvalidMailAddressException()
        {
        }

        public InvalidMailAddressException(string message) : base(message)
        {
        }

        public InvalidMailAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMailAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}