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
    public class DetailsModel : PageModel
    {
        private readonly BookmarksWebApp.Data.BookmarksContext _context;

        public DetailsModel(BookmarksWebApp.Data.BookmarksContext context)
        {
            _context = context;
        }

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
    }
}
