using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksAPI.Services;
using BooksAPI.Models;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PublishersController : ControllerBase
    {
        private IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        //GET /api/publishers
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_publisherService.GetAll());
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("GetAllPublishers", ex.Message);
                return NotFound(ModelState);
            }
        }

        //GET /api/publishers/publisherId
        [HttpGet("/api/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_publisherService.Get(id));
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("GetPublisher", ex.Message);
                return NotFound(ModelState);
            }
        }

        //Post /api/publishers
        [HttpPost]
        public IActionResult Post([FromBody] Publisher newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher);
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("AddPublisher", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        //Put /api/publishers/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher updatedPublisher)
        {
            try
            {
                _publisherService.Update(updatedPublisher);
                return Ok(updatedPublisher);
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("UpdatePublisher", ex.Message);
                return BadRequest(ModelState);
            }   
        }

        //Delete /api/publishers/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Publisher publisher = _publisherService.Get(id);
                _publisherService.Delete(publisher);
                return NoContent();
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("DeletePublisher", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
