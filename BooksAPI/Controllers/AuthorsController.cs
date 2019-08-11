using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using BooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService { get; set; }

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        //Get api/authors
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_authorService.GetAll());
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("GetAllAuthors", ex.Message);
                return NotFound(ModelState);
            }
        }

        //Get api/authors/Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Author author = _authorService.Get(id);
                return Ok(author);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("Get", ex.Message);
                return NotFound(ModelState);
            }
        }

        //Post api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            try
            {
                _authorService.Add(newAuthor);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddAuthor", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }

        //Put api/author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updatedAuthor)
        {
            try
            {
                Author author = _authorService.Update(updatedAuthor);
                return Ok(updatedAuthor);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("UpdateAuthor", ex.Message);
                return NotFound(ModelState);
            }
        }

        //Delete api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Author author = _authorService.Get(id);
                _authorService.Delete(author);
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("DeleteAuthor", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
