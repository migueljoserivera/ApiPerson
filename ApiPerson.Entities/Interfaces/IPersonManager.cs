using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Interfaces
{
    public interface IPersonManager
    {
        void Save(Person person);
        Person Get(int Id);
        IEnumerable<Person> GetAll();
        void Remove(int Id);
    }
}
