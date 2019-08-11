using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();

        Author Get(int id);

        Author Add(Author newAuthor);

        Author Update(Author updatedAuthor);

        void Delete(Author author);
    }
}
