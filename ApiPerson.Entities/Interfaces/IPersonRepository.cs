using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Interfaces
{
    /// <summary>
    /// Interface for Person Repository
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Insert new person
        /// </summary>
        void Insert(Person person);

        /// <summary>
        /// Update current person if this has their Id
        /// </summary>
        void Update(Person person);

        /// <summary>
        /// Get Person by Id
        /// </summary>
        Person Get(int Id);

        /// <summary>
        /// Retrieve all persons stored without filter
        /// </summary>
        IEnumerable<Person> GetAll();

        /// <summary>
        /// Delete person by Id
        /// </summary>
        void Remove(Person person);
    }
}
