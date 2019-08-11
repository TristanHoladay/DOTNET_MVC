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
    public class BooksController : ControllerBase
    {

        private IBookService _bookService { get; set; }

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book book = _bookService.Get(id);

            if (book == null)
                return NotFound();

            return Ok(_bookService.Get(id));

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book newbook)
        {
            try
            {
                _bookService.Add(newbook);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);

            }

            return CreatedAtAction("Get", new { Id = newbook.Id }, newbook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updatedBook)
        {

            Book book = _bookService.Update(updatedBook);

            if (book == null)
                return NotFound();

            return Ok(updatedBook);
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            Book book = _bookService.Get(id);
            if (book == null)
                return NotFound();

            _bookService.Delete(book);
                return NoContent();
        
        }
    }
}
