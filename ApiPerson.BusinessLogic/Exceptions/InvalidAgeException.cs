using System;
using System.Runtime.Serialization;

namespace ApiPerson.BusinessLogic.Exceptions
{
    /// <summary>
    /// Exception used when Age is invalid
    /// </summary>
    [Serializable]
    public class InvalidAgeException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidAgeException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidAgeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic Exception</param>
        public InvalidAgeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Store all data needed to serialize or deserialize object</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected InvalidAgeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}