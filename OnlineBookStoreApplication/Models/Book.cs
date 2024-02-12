using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApplication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int BookNumber { get; set; }

        public string PublishedDate { get; set; }

        public string Image { get; set; }
    }
}
