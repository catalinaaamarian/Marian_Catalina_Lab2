using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Marian_Catalina_Lab2.Data;
using Marian_Catalina_Lab2.Models;

namespace Marian_Catalina_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList { get; set; } = new List<AssignedCategoryData>();

        public void PopulateAssignedCategoryData(Marian_Catalina_Lab2Context context, Book book)
        {
            var allCategories = context.Category;

            AssignedCategoryDataList = new List<AssignedCategoryData>();
            if (allCategories != null && book != null && book.BookCategories != null)
            {
                var bookCategories = new HashSet<int>(book.BookCategories.Select(c => c.Category?.ID ?? 0));

                foreach (var cat in allCategories)
                {
                    if (cat != null)
                    {
                        AssignedCategoryDataList.Add(new AssignedCategoryData
                        {
                            CategoryID = cat.ID,
                            Name = cat.CategoryName ?? "Unknown",
                            Assigned = bookCategories.Contains(cat.ID)
                        });
                    }
                }
            }
        }

        public void UpdateBookCategories(Marian_Catalina_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            if (bookToUpdate?.BookCategories != null)
            {
                var bookCategories = new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.Category?.ID ?? 0));

                foreach (var cat in context.Category ?? Enumerable.Empty<Category>())
                {
                    if (cat != null)
                    {
                        if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                        {
                            if (!bookCategories.Contains(cat.ID))
                            {
                                bookToUpdate.BookCategories.Add(
                                    new BookCategory
                                    {
                                        BookID = bookToUpdate.ID,
                                        CategoryID = cat.ID
                                    });
                            }
                        }
                        else
                        {
                            if (bookCategories.Contains(cat.ID))
                            {
                                BookCategory? courseToRemove = bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                                if (courseToRemove != null)
                                {
                                    context.Remove(courseToRemove);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
