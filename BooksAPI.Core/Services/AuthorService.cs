using BooksAPI.Data;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Services
{
    public class AuthorService : IAuthorService
    {
        
        private readonly BookContext _bookContext;

        //Inject BookContext
        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Author> GetAll()
        {
            if(_bookContext.authors.ToList() == null)
            {
                throw new ApplicationException("Could not return list of authors.");
            }

            return _bookContext.authors
                .Include(a => a.Books)
                .ToList();
        }

        public Author Get(int id)
        {
            
            Author author = _bookContext.authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                throw new ApplicationException("Could not find selected author.");
            }

            return _bookContext.authors
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
                
        }

        public Author Add(Author newAuthor)
        {
            Author author = _bookContext.authors.FirstOrDefault((a => a.FirstName == newAuthor.FirstName && a.LastName == newAuthor.LastName));

            if(author != null)
            {
                throw new ApplicationException("You can't duplicate identical Author entries.");
            }
            else
            {
                _bookContext.authors.Add(newAuthor);
                _bookContext.SaveChanges();
            }

            return newAuthor;
        }

        public Author Update(Author updatedAuthor)
        {
            Author currentAuthor = _bookContext.authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);

            if (currentAuthor == null)
            {
                throw new ApplicationException("Author does not exist to update.");
            }

            _bookContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);
            _bookContext.authors.Update(currentAuthor);

            _bookContext.SaveChanges();

            return updatedAuthor;
        }

        public void Delete(Author author)
        {
            Author delAuthor = _bookContext.authors.FirstOrDefault(a => a.Id == author.Id);

            //If no author break
            if (delAuthor == null) return;

            _bookContext.authors.Remove(delAuthor);
            _bookContext.SaveChanges();
        }
    }
}
