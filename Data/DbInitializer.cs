using Marian_Catalina_Lab2.Models;

namespace Marian_Catalina_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<LibraryContext>();

            if (context.Book.Any())
            {
                return; // BD deja creată
            }

            // GENRE
            context.Genre.AddRange(
                new Genre { Name = "Roman" },
                new Genre { Name = "Nuvelă" },
                new Genre { Name = "Poezie" }
            );

            // AUTHORS
            context.Authors.AddRange(
                new Authors { FirstName = "Mihail", LastName = "Sadoveanu" },
                new Authors { FirstName = "George", LastName = "Călinescu" },
                new Authors { FirstName = "Mircea", LastName = "Eliade" }
            );

            context.SaveChanges();

            // BOOKS
            context.Book.AddRange(
                new Book { Title = "Baltagul", Author = "Mihail Sadoveanu", Price = 22, GenreID = 1, AuthorID = 1 },
                new Book { Title = "Enigma Otiliei", Author = "George Călinescu", Price = 18, GenreID = 2, AuthorID = 2 },
                new Book { Title = "Maitreyi", Author = "Mircea Eliade", Price = 27, GenreID = 3, AuthorID = 3 }
            );

            // CUSTOMERS
            context.Customer.AddRange(
                new Customer { Name = "Popescu Marcela", Adress = "Str. Plopilor, 24", BirthDate = DateTime.Parse("1979-09-01") },
                new Customer { Name = "Mihailescu Cornel", Adress = "Str. Bucuresti, 45, ap.2", BirthDate = DateTime.Parse("1969-07-08") }
            );

            context.SaveChanges();
        }
    }
}
