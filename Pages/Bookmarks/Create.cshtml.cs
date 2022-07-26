using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookmarksWebApp.Data;
using BookmarksWebApp.Models;

namespace BookmarksWebApp.Pages.Bookmarks
{
    public class CreateModel : PageModel
    {
        private readonly BookmarksWebApp.Data.BookmarksContext _context;

        public CreateModel(BookmarksWebApp.Data.BookmarksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bookmark == null || Bookmark == null)
            {
                return Page();
            }

            _context.Bookmark.Add(Bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
