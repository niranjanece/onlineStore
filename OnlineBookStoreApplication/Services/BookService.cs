using Microsoft.Extensions.FileProviders;
using OnlineBookStoreApplication.Interfaces;
using OnlineBookStoreApplication.Models;
using OnlineBookStoreApplication.Models.DTOs;
using OnlineBookStoreApplication.Repositories;

namespace OnlineBookStoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<int, Book> _bookRepository;

        public BookService(IRepository<int,Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public BookDTO AddBook(BookDTO bookDTO)
        {
            if(bookDTO != null)
            {
                Book book = new Book() { 
                    Title = bookDTO.Title,
                    Author = bookDTO.Author,
                    Genre = bookDTO.Genre,
                    PublishedDate = bookDTO.PublishedDate,
                    BookNumber = bookDTO.BookNumber,
                    Image = "http://localhost:5090/Images/" + bookDTO.Image.FileName
                };
                var result = _bookRepository.Add(book);
                if (result != null)
                {
                    return bookDTO;
                }
            }
            
            return null;
        }

        public List<Book> GetAllBook()
        {
            var books = _bookRepository.GetAll();
            if (books != null)
                return books.ToList();
            return null;
        }

        public List<Book> GetAuthor(string author)
        {
            try
            {
                if (author == "All")
                {
                    if(GetAllBook().ToList().Count > 0)
                     return GetAllBook().ToList();
                }
                var book = GetAllBook().Where(b => b.Author == author).ToList();
                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch(Exception e) {
                return null;
            }
            
        }

        public Book GetById(int id)
        {
            var result = _bookRepository.GetById(id);
            if( result != null )
                return result;
            return null;
        }

        public List<Book> GetGenre(string genre)
        {
            try
            {
                if (genre == "All")
                {
                    return GetAllBook().ToList();
                }
                var book = GetAllBook().Where(b => b.Genre == genre).ToList();

                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<Book> GetTitle(string title)
        {
            try
            {
                if (title == "All")
                {
                    return GetAllBook().ToList();
                }
                var book = GetAllBook().Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public bool RemoveBook(int id)
        {
            var book = _bookRepository.Delete(id);
            if (book != null)
                return true;
            return false;
        }

       

        public Book UpdateBook(int id, Book bookDTO)
        {
            var book = _bookRepository.GetById(id);
            if(book != null)
            {
                book.Author = bookDTO.Author;
                book.BookNumber = bookDTO.BookNumber;
                book.Title = bookDTO.Title;
                book.PublishedDate = bookDTO.PublishedDate;
                book.Genre = bookDTO.Genre;

                var result = _bookRepository.Update(book);
                return bookDTO;
            }
            return null;
        }
    }
}
