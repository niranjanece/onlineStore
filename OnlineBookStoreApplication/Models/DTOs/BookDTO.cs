namespace OnlineBookStoreApplication.Models.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int BookNumber { get; set; }

        public string PublishedDate { get; set; }

        public IFormFile? Image { get; set; }
    }
}
