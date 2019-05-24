using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.BusinessLogic.Managers;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiPerson.BusinessLogicTests
{
    public class SavePersonManagerTest
    {
        [Fact]
        public void SaveWhenPersonHasInvalidName_InvalidPropertyExceptionMustBeFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person();

            InvalidPropertyException exception = Assert.Throws<InvalidPropertyException>(
                () => personManager.Save(person)
            );

            Assert.IsType<InvalidPropertyException>(exception);
        }

        [Fact]
        public void SaveWhenPersonHasInvalidLastname_InvalidPropertyExceptionMustBeFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Name = "Miguel",
                Lastname = ""
            };

            InvalidPropertyException exception = Assert.Throws<InvalidPropertyException>(
                () => personManager.Save(person)
            );

            Assert.IsType<InvalidPropertyException>(exception);
        }

        [Fact]
        public void SaveWhenPersonHasInvalidAge_InvalidAgeExceptionMustBeFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Name = "Miguel",
                Lastname = "Rivera",
                Age = -1
            };

            InvalidAgeException exception = Assert.Throws<InvalidAgeException>(
                () => personManager.Save(person)
            );

            Assert.IsType<InvalidAgeException>(exception);
        }

        [Fact]
        public void SaveWhenPersonHasInvalidEmailAddress_InvalidEmailAddressExceptionMustBeFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Name = "Miguel",
                Lastname = "Rivera",
                Age = 30,
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        Address = "mrivera$hotmail.com"
                    }
                }
            };

            InvalidMailAddressException exception = Assert.Throws<InvalidMailAddressException>(
                () => personManager.Save(person)
            );

            Assert.IsType<InvalidMailAddressException>(exception);
        }

        [Fact]
        public void SaveWhenPersonHasDuplicatedEmailAddress_DuplicatedEmailAddressExceptionMustBeFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Name = "Miguel",
                Lastname = "Rivera",
                Age = 30,
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        Address = "mrivera@hotmail.com"
                    },
                    new Email()
                    {
                        Address = "mrivera@hotmail.com"
                    }
                }
            };

            DuplicatedEmailException exception = Assert.Throws<DuplicatedEmailException>(
                () => personManager.Save(person)
            );

            Assert.IsType<DuplicatedEmailException>(exception);
        }

        [Fact]
        public void SaveWhenIsaNewPerson_PersonMustBeInserted()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.Insert(It.IsAny<Person>())).Callback((Person personInserted) =>
            {
                personInserted.Id = 1000;
            });
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Name = "Miguel",
                Lastname = "Rivera",
                Age = 30,
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        Address = "mrivera@hotmail.com"
                    }
                }
            };

            personManager.Save(person);

            Assert.Equal(1000, person.Id);
        }

        [Fact]
        public void SaveWhenIsExistingPerson_PersonMustBeUpdated()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.Insert(It.IsAny<Person>()));
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );
            Person person = new Person()
            {
                Id = 1000,
                Name = "Miguel",
                Lastname = "Rivera",
                Age = 30,
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        Address = "mrivera@hotmail.com"
                    }
                }
            };

            personManager.Save(person);

            Assert.Equal(1000, person.Id);
        }
    }
}
