using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public bool Verified { get; set; }
    }
}
