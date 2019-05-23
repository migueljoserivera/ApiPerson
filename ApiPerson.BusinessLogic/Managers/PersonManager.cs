using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.BusinessLogic.Managers
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonManager(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }

        public Person Get(int Id)
        {
            return _PersonRepository.Get(Id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _PersonRepository.GetAll();
        }

        public void Remove(Person person)
        {
            _PersonRepository.Remove(person);
        }

        public void Save(Person person)
        {
            _PersonRepository.Save(person);
        }
    }
}
