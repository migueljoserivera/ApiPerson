using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.BusinessLogic.Managers;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using Moq;
using System;
using Xunit;

namespace ApiPerson.BusinessLogicTests
{
    public class GetPersonManagerTest
    {
        [Fact]
        public void GetWhenIdIsInvalid_InvalidIdExceptionMustFire()
        {
            PersonManager personManager = new PersonManager(new Mock<IPersonRepository>().Object);

            InvalidIdException exception = Assert.Throws<InvalidIdException>(() => personManager.Get(0));

            Assert.IsType<InvalidIdException>(exception);
        }

        [Fact]
        public void GetWhenPersonDontExists_NotFoundIdExceptionMustFire()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.Get(1)).Returns(
                () => { return null; }
              );
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );

            NotFoundException exception = Assert.Throws<NotFoundException>(
                () => personManager.Get(1)
              );

            Assert.IsType<NotFoundException>(exception);
        }

        [Fact]
        public void GetWhenPersonExists_PersonMustBeReturned()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(r => r.Get(1)).Returns(
                () => { return new Person() { Name = "Miguel" }; }
             );
            PersonManager personManager = new PersonManager(
                repositoryMock.Object
              );

            Person person = personManager.Get(1);

            Assert.Equal("Miguel", person.Name);
        }
    }
}
