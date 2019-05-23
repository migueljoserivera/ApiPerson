using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPerson.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _PersonContext;

        public PersonRepository(PersonContext PersonContext)
        {
            _PersonContext = PersonContext;
        }

        public Person Get(int Id)
        {
            return _PersonContext.Persons.Where(p => p.Id == Id).SingleOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            return _PersonContext.Persons.AsEnumerable();
        }

        public void Save(Person person)
        {
            _PersonContext.Persons.Add(person);
            _PersonContext.SaveChanges();
        }

        public void Remove(Person person)
        {
            _PersonContext.Remove(person);
        }
    }
}
