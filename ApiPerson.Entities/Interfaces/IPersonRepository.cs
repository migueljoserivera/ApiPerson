using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Interfaces
{
    public interface IPersonRepository
    {
        void Insert(Person person);
        void Update(Person person);
        Person Get(int Id);
        IEnumerable<Person> GetAll();
        void Remove(Person person);
    }
}
