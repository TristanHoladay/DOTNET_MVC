using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.ApiModels
{
    public class PublisherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundedYear { get; set; }
        public string CountryOfOrigin { get; set; }
        public string HeadQuartersLocation { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
