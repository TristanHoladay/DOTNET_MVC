﻿using BooksAPI.Data;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Book> GetAll()
        {
            //Return the DbSet Books as a list
           return _bookContext.books.ToList();
        }

        public Book Get(int id)
        {
            return _bookContext.books.FirstOrDefault(b => b.Id == id);
        }

        public Book Add(Book newBook)
        {
            Book book = _bookContext.books.FirstOrDefault(b => b.Title == newBook.Title);

            if(book != null)
            {
                throw new ApplicationException("You cannot make identical duplicate entries of books.");
            }
            _bookContext.books.Add(newBook);
            _bookContext.SaveChanges();

            return newBook;
        }

        public Book Update(Book updatedBook)
        {
            Book currentBook = _bookContext.books.FirstOrDefault(b => b.Id == updatedBook.Id);

            if (currentBook == null)
                return null;

            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);
            _bookContext.books.Update(currentBook);

            _bookContext.SaveChanges();

            return updatedBook;
        }

        public void Delete(Book book)
        {
            Book delBook = _bookContext.books.FirstOrDefault(b => b.Id == book.Id);
            //if null then break
            if (delBook == null) return;
            //else
            _bookContext.books.Remove(delBook);
            _bookContext.SaveChanges();

        }
    }


}