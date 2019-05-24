using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPerson.BusinessLogic.Managers
{
    /// <summary>
    /// Used for manage Person objects
    /// </summary>
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _PersonRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PersonRepository">An implementation of IPersonRepository is necessary for persistence purposes.</param>
        public PersonManager(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }

        /// <summary>
        /// Get Person by Id
        /// </summary>
        /// <param name="Id">Unique identifier from person</param>
        /// <returns>Person found</returns>
        /// <exception cref="NotFoundException">When person is not found</exception>
        /// <exception cref="InvalidIdException">When id is invalid</exception>
        public Person Get(int Id)
        {
            CheckId(Id);

            Person person = _PersonRepository.Get(Id);
            if (person == null)
            {
                throw new NotFoundException($"Person with id {Id} found");
            }
            return person;
        }

        private void CheckId(int id)
        {
            if (!IsValidId(id))
            {
                throw new InvalidIdException("Invalid Id");
            }
        }

        private bool IsValidId(int id)
        {
            return id > 0;
        }

        /// <summary>
        /// Retrieve all persons stored without filter
        /// </summary>
        /// <returns>All persons stored</returns>
        public IEnumerable<Person> GetAll()
        {
            return _PersonRepository.GetAll();
        }

        /// <summary>
        /// Delete person by Id
        /// </summary>
        /// <param name="Id">Unique identifier of person</param>
        /// <exception cref="NotFoundException">When person is not found</exception>
        public void Remove(int Id)
        {
            Person person = Get(Id);

            _PersonRepository.Remove(person);
        }

        /// <summary>
        /// Insert new person or update person if this has their Id
        /// </summary>
        /// <param name="person">Person to save</param>
        /// <exception cref="InvalidPropertyException">If name or lastname is null or empty</exception>
        /// <exception cref="DuplicatedEmailException">If email is duplicated in the collection</exception>
        /// <exception cref="InvalidMailAddressException">If email is not valid</exception>
        /// <exception cref="InvalidAgeException">If age of person is not valid</exception>
        public void Save(Person person)
        {
            Validate(person);

            if (IsValidId(person.Id))
            {
                _PersonRepository.Update(person);
            }
            else
            {
                _PersonRepository.Insert(person);
            }
        }

        private void Validate(Person person)
        {
            ValidateName(person.Name);
            ValidateLastname(person.Lastname);
            ValidateAge(person.Age);
            ValidateEmails(person.Emails);
        }

        private void ValidateEmails(IEnumerable<Email> emails)
        {
            foreach (Email email in emails)
            {
                ValidateEmailAddress(email.Address);
                ValidateIfIsDuplicated(emails, email.Address);
            }
        }

        private void ValidateIfIsDuplicated(IEnumerable<Email> emails, string address)
        {
            if (emails.Where(e => e.Address == address).Count() > 1)
            {
                throw new DuplicatedEmailException($"{address} address is duplicated");
            }
        }

        private void ValidateEmailAddress(string address)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(address);
                if (mailAddress.Address != address)
                {
                    throw new InvalidMailAddressException($"{address} is not valid");
                }
            }
            catch
            {
                throw new InvalidMailAddressException($"{address} is not valid");
            }
        }

        private void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new InvalidAgeException($"The age is incorrect");
            }
        }

        private void ValidateName(string name)
        {
            CheckIfIsNullOrEmpty(name, "Name");
        }

        private void ValidateLastname(string lastName)
        {
            CheckIfIsNullOrEmpty(lastName, "Lastname");
        }

        private static void CheckIfIsNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidPropertyException($"{propertyName} cannot be null or empty");
            }
        }
    }
}
