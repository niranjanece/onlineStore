using Microsoft.EntityFrameworkCore;
using OnlineBookStoreApplication.Models;

namespace OnlineBookStoreApplication.Context
{
    public class StoreContext : DbContext 
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
