using Microsoft.EntityFrameworkCore;
using Marian_Catalina_Lab2.Models;

namespace Marian_Catalina_Lab2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<Authors> Authors { get; set; } = default!;
    }
}
