using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;


namespace BooksAPI.Services
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAll();

        Publisher Get(int id);
        Publisher Add(Publisher newPublisher);
        Publisher Update(Publisher updatedPublisher);
        void Delete(Publisher publisher);
    }
}
