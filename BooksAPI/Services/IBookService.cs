﻿using BooksAPI.Models;
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

        Book Add(Book newBook);

        Book Update(Book updatedBook);

        void Delete(Book book);

    }
}
