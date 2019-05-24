using System;
using System.Runtime.Serialization;

namespace ApiPerson.BusinessLogic.Managers
{
    [Serializable]
    public class DuplicatedEmailException : Exception
    {
        public DuplicatedEmailException()
        {
        }

        public DuplicatedEmailException(string message) : base(message)
        {
        }

        public DuplicatedEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}