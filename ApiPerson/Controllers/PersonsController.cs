using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPerson.BusinessLogic.Exceptions;
using ApiPerson.Entities.Interfaces;
using ApiPerson.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPerson.Controllers
{
    /// <summary>
    /// This controller allow the interaction with Person resource
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonManager _PersonManager;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="PersonManager">Implementation of IPersonManager</param>
        public PersonsController(IPersonManager PersonManager)
        {
            _PersonManager = PersonManager;
        }

        /// <summary>
        /// You can get all persons using Http Method Get
        /// </summary>
        /// <returns>Returns all persons from Manager</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            try
            {
                return Ok(_PersonManager.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// You can get only one person by id using Http Method Get
        /// </summary>
        /// <returns>Returns only one person by Id from manager</returns>
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            try
            {
                return Ok(_PersonManager.Get(id));
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// It creates a new person using Post Http Method
        /// </summary>
        /// <returns>Returns person created with his Id</returns>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            try
            {
                _PersonManager.Save(person);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// It update the data of one person using Http Put Method
        /// </summary>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person person)
        {
            try
            {
                person.Id = id;
                _PersonManager.Save(person);
                Ok();
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }

        /// <summary>
        /// It delete a person by Id using Delete Http Method 
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _PersonManager.Remove(id);
                Ok();
            }
            catch (NotFoundException e)
            {
                NotFound(e.Message);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }
    }
}
