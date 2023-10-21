using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Marian_Catalina_Lab2.Data;
using Marian_Catalina_Lab2.Models;

namespace Marian_Catalina_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Marian_Catalina_Lab2.Data.Marian_Catalina_Lab2Context _context;

        public IndexModel(Marian_Catalina_Lab2.Data.Marian_Catalina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;
        public IList<Book> Book { get; set; } = default!;  // Adaugăm o proprietate pentru Book


        public async Task OnGetAsync()
        {
            // Ia toate cărțile și include informații despre editor
            Book = await _context.Book.Include(b => b.Publisher).ToListAsync();

            // Ia toți editorii dacă nu au fost deja obținuți
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }


    }
}
