using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using BooksAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Publisher> GetAll()
        {
            if(_bookContext.publishers.ToList() == null)
            {
                throw new ApplicationException("Could not return list of publishers");
            }

            return _bookContext.publishers
                .Include(p => p.Books)
                .ToList();
        }

        public Publisher Get(int id)
        {
            Publisher publisher = _bookContext.publishers.FirstOrDefault(p => p.Id == id);
            if(publisher == null)
            {
                throw new ApplicationException("Publisher does not exist.");
            }

            return publisher;
        }

        public Publisher Add(Publisher newPublisher)
        {
            Publisher publisher = _bookContext.publishers.FirstOrDefault(p => p.Name == newPublisher.Name);

            if(publisher != null)
            {
                throw new ApplicationException("Cannot have duplicate entries of publishers.");
            }

            _bookContext.publishers.Add(newPublisher);
            _bookContext.SaveChanges();

            return newPublisher;
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            Publisher currentPublisher = _bookContext.publishers.FirstOrDefault(p => p.Id == updatedPublisher.Id);

            if(currentPublisher == null)
            {
                throw new ApplicationException("Could not find publisher to update.");
            }

            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatedPublisher);
            _bookContext.publishers.Update(currentPublisher);

            _bookContext.SaveChanges();

            return updatedPublisher;

        }

        public void Delete(Publisher publisher)
        {
            _bookContext.publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }
    }
}
