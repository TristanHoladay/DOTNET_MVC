using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "The maximum length is 250 characters.")]
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

    

        
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
