using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Models
{
    public class Person
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Person's lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Person's age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Person's emails address
        /// </summary>
        public IEnumerable<Email> Emails { get; set; }
    }
}
