using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Marian_Catalina_Lab2.Models;

namespace Marian_Catalina_Lab2.Data
{
    public class Marian_Catalina_Lab2Context : DbContext
    {
        public Marian_Catalina_Lab2Context(DbContextOptions<Marian_Catalina_Lab2Context> options)
            : base(options)

        {
        }

        public DbSet<Marian_Catalina_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Marian_Catalina_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Marian_Catalina_Lab2.Models.Category>? Category { get; set; }
        public DbSet<Marian_Catalina_Lab2.Models.Author>? Author { get; set; }
    }
}
