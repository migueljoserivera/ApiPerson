﻿using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPerson.Entities.Interfaces
{
    /// <summary>
    /// Interface for Person management
    /// </summary>
    public interface IPersonManager
    {
        /// <summary>
        /// Insert new person or update if this has their Id
        /// </summary>
        void Save(Person person);

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
        void Remove(int Id);
    }
}
