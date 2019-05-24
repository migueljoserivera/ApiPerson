using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.BusinessLogic.Managers;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using Moq;
using System;
using Xunit;

namespace ApiPerson.BusinessLogicTests
{
    public class RemovePersonManagerTest
    {
        [Fact]
        public void RemoveWhenPersonDontExists_NotFoundExceptionMustFire()
        {
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(r => r.Get(2)).Returns(
                    () => { return new Person(); }
                );
            PersonManager personManager = new PersonManager(personRepository.Object);

            NotFoundException exception = Assert.Throws<NotFoundException>(() => personManager.Remove(1));

            Assert.IsType<NotFoundException>(exception);
        }

        [Fact]
        public void RemoveWhenPersonExists_PersonMustBeDeleted()
        {
            bool deleted = false;
            var personRepository = new Mock<IPersonRepository>();
            Person personToDelete = new Person() { Id = 1 };
            personRepository.Setup(r => r.Get(1)).Returns(
                    () => { return personToDelete; }
                );
            personRepository.Setup(r => r.Remove(personToDelete)).Callback(() => {
                deleted = true;
            });
            PersonManager personManager = new PersonManager(personRepository.Object);

            personManager.Remove(1);

            Assert.True(deleted);
        }
    }
}
