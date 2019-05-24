using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPerson.DataAccess.Repositories
{
    /// <summary>
    /// Person repository that use Entity Framework context for store data
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _PersonContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PersonContext">We need to use a PersonContext</param>
        public PersonRepository(PersonContext PersonContext)
        {
            _PersonContext = PersonContext;
        }

        /// <summary>
        /// Return person by Id
        /// </summary>
        /// <param name="Id">Unique identifier</param>
        /// <returns>Person found</returns>
        public Person Get(int Id)
        {
            return _PersonContext.Persons.Where(p => p.Id == Id).SingleOrDefault();
        }

        /// <summary>
        /// Retrieve all persons stored in database
        /// </summary>
        /// <returns>All persons stored</returns>
        public IEnumerable<Person> GetAll()
        {
            return _PersonContext.Persons.AsEnumerable();
        }

        /// <summary>
        /// Delete person by Id
        /// </summary>
        /// <param name="Id">Unique identifier of person</param>
        public void Remove(Person person)
        {
            _PersonContext.Remove(person);
        }

        /// <summary>
        /// Insert a new person in database
        /// </summary>
        /// <param name="person">Person object</param>
        public void Insert(Person person)
        {
            _PersonContext.Persons.Add(person);
            _PersonContext.SaveChanges();
        }

        /// <summary>
        /// Update current person in database
        /// </summary>
        /// <param name="person">Person object</param>
        public void Update(Person person)
        {
            _PersonContext.Persons.Update(person);
            _PersonContext.SaveChanges();
        }
    }
}
