using OnlineBookStoreApplication.Models;
using OnlineBookStoreApplication.Models.DTOs;

namespace OnlineBookStoreApplication.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBook();
        BookDTO AddBook(BookDTO bookDTO);
        Book UpdateBook(int id, Book bookDTO);

        List<Book> GetGenre(string genre);
        List<Book> GetTitle(string title);
        List<Book> GetAuthor(string author);
        Book GetById(int id);
        bool RemoveBook(int id);

   

    }
}
