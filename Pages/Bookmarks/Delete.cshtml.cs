using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookmarksWebApp.Data;
using BookmarksWebApp.Models;

namespace BookmarksWebApp.Pages.Bookmarks
{
    public class DeleteModel : PageModel
    {
        private readonly BookmarksWebApp.Data.BookmarksContext _context;

        public DeleteModel(BookmarksWebApp.Data.BookmarksContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bookmark Bookmark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookmark == null)
            {
                return NotFound();
            }

            var bookmark = await _context.Bookmark.FirstOrDefaultAsync(m => m.ID == id);

            if (bookmark == null)
            {
                return NotFound();
            }
            else 
            {
                Bookmark = bookmark;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bookmark == null)
            {
                return NotFound();
            }
            var bookmark = await _context.Bookmark.FindAsync(id);

            if (bookmark != null)
            {
                Bookmark = bookmark;
                _context.Bookmark.Remove(Bookmark);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
