using Marian_Catalina_Lab2.Models; // Directiva de using pentru spațiul de nume


namespace Marian_Catalina_Lab2.Models
{
    public class BookCategory
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public Book? Book { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public BookCategory()
        {
            Category = new Category(); // Inițializare a obiectului Category
        }
    }
}
