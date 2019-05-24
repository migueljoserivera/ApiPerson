using System;
using System.Runtime.Serialization;

namespace ApiPerson.BusinessLogic.Exceptions
{
    /// <summary>
    /// Exception used when Id is invalid
    /// </summary>
    [Serializable]
    public class InvalidIdException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidIdException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidIdException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic Exception</param>
        public InvalidIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Store all data needed to serialize or deserialize object</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}