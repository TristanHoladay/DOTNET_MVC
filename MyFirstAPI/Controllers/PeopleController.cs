using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        
        private static readonly List<Person> _people = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Luke Skywalker",
                HairColor = "blond"
            },
            new Person
            {
                Id = 5,
                Name = "Leia Organa",
                HairColor = "brown"
            }

        };

        // GET api/people
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_people);
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Person person = _people.FirstOrDefault(p => p.Id == id);

            if (id > 5 || person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person); 
            }
        }

        // POST api/people
        [HttpPost]
        public IActionResult Post([FromBody] Person newPerson)
        {
            _people.Add(newPerson);
            return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person newPerson)
        {
            Person oldPerson = _people.FirstOrDefault(p => p.Id == id);
            
            if(newPerson == null)
            {
                return NotFound();
            }
            else
            {
                oldPerson = newPerson;
                return Ok(oldPerson);
            }

        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Person person = _people.FirstOrDefault(p => p.Id == id);
            _people.Remove(person);

            return Ok(_people);

        }
    }
}
