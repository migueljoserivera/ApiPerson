using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (IsValidId(id))
            {
                throw new InvalidIdException("Invalid Id");
            }
        }

        private bool IsValidId(int id)
        {
            return id < 1;
        }

        public IEnumerable<Person> GetAll()
        {
            return _PersonRepository.GetAll();
        }

        public void Remove(int id)
        {
            Person person = Get(id);

            if (person != null)
            {
                throw new NotFoundException();
            }

            _PersonRepository.Remove(person);
        }

        private void CheckIfPersonExists(Person person)
        {
            if (IsValidId(person.Id) && Get(person.Id) != null)
            {
                throw new NotFoundException();
            }
        }

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
            ValidateLastname(person.Name);
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
            var mailAddress = new System.Net.Mail.MailAddress(address);
            if (mailAddress.Address != address)
            {
                throw new InvalidMailAddressException($"{address} is not valid");
            }
        }

        private void ValidateAge(int age)
        {
            if (age > -1)
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
