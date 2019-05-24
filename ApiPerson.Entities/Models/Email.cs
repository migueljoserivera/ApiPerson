using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Models
{
    /// <summary>
    /// Email entity
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// bool that detects if email is verified or not
        /// </summary>
        public bool Verified { get; set; }
    }
}
