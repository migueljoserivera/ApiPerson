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
    public class GetAllPersonManagerTest
    {
        [Fact]
        public void GetAllWhenDontTherePersons_EmptyListMustBeReturned()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.GetAll()).Returns(
                () => { return new List<Person>(); }
              );
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );

            var persons = personManager.GetAll().ToList();

            Assert.Empty(persons);
        }

        [Fact]
        public void GetAllWhenThereArePersons_PeopleInDatabaseMustBeReturned()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.GetAll()).Returns(
                () =>
                {
                    return new List<Person>()
                    {
                        new Person() { Name = "Miguel" },
                        new Person() { Name = "Jose" }
                    };
                }
              );
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );

            var persons = personManager.GetAll().ToList();

            Assert.Equal(2, persons.Count());
        }
    }
}
