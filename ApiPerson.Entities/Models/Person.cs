using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public IEnumerable<Email> Emails { get; set; }
    }
}
