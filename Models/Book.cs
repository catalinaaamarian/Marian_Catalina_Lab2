namespace Marian_Catalina_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }

        // Relation with Genre
        public int? GenreID { get; set; }
        public Genre? Genre { get; set; }

        // Relation with Authors
        public int? AuthorID { get; set; }
        public Authors? Authors { get; set; }

        // Relation with Orders
        public ICollection<Order>? Orders { get; set; }
    }
}
