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
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonManager _PersonManager;

        public PersonsController(IPersonManager PersonManager)
        {
            _PersonManager = PersonManager;
        }

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
