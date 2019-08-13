using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book Get(int id);

        IEnumerable<Book> GetBooksForAuthor(int id);
        IEnumerable<Book> GetBooksForPublisher(int publisherId);

        Book Add(Book newBook);

        Book Update(Book updatedBook);

        void Delete(Book book);

    }
}
