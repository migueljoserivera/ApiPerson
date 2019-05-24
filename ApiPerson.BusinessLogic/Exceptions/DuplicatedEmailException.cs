using System;
using System.Runtime.Serialization;

namespace ApiPerson.BusinessLogic.Managers
{
    /// <summary>
    /// Exception used when Email is duplicated
    /// </summary>
    [Serializable]
    public class DuplicatedEmailException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DuplicatedEmailException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public DuplicatedEmailException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic Exception</param>
        public DuplicatedEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Store all data needed to serialize or deserialize object</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected DuplicatedEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}