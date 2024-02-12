using Microsoft.EntityFrameworkCore;
using OnlineBookStoreApplication.Context;
using OnlineBookStoreApplication.Interfaces;
using OnlineBookStoreApplication.Models;

namespace OnlineBookStoreApplication.Repositories
{
    public class BookRepository : IRepository<int, Book>
    {
        private readonly StoreContext _context;

        public BookRepository(StoreContext context)
        {
            _context = context; 
        }
        public Book Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges(); 
            return entity;
        }

        public Book Delete(int key)
        {
            var book = GetById(key);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return book;
            }
            return null;
        }

        public IList<Book> GetAll()
        {
            if (_context.Books.Count() == 0)
            {
                return null;
            }
            return _context.Books.ToList();
        }

        public Book GetById(int key)
        {
            var book = _context.Books.SingleOrDefault(b => b.BookId == key);
            return book;
        }

        public Book Update(Book entity)
        {
            var book = GetById(entity.BookId);
            if (book != null)
            {
                _context.Entry<Book>(book).State = EntityState.Modified;
                _context.SaveChanges();
                return book;
            }
            return null;
        }
    }
}
