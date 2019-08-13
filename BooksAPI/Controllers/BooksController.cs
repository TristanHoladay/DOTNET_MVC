using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using BooksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using BooksAPI.ApiModels;

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
            var bookModels = _bookService
                .GetAll()
                .ToApiModels();

            return Ok(bookModels);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);

            if (book == null)
                return NotFound();

            return Ok(book.ToApiModel());

        }

        // GET /api/authors/{authorId}/books
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();

            return Ok(bookModels);
        }

        //GET /api/publishers/{publisherId}/books
        [HttpGet("/api/publishers/{publisherId}/books")]
        public IActionResult GetBooksForPublisher(int publisherId)
        {
            var bookModels = _bookService
                .GetBooksForPublisher(publisherId)
                .ToApiModels();

            return Ok(bookModels);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] BookModel newbook)
        {
            try
            {
                _bookService.Add(newbook.ToDomainModel());
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
        public IActionResult Put(int id, [FromBody] BookModel updatedBook)
        {

            var book = _bookService.Update(updatedBook.ToDomainModel());

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
