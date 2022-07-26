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
    public class IndexModel : PageModel
    {
        private readonly BookmarksWebApp.Data.BookmarksContext _context;

        public IndexModel(BookmarksWebApp.Data.BookmarksContext context)
        {
            _context = context;
        }

        public IList<Bookmark> Bookmark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookmark != null)
            {
                Bookmark = await _context.Bookmark.ToListAsync();
            }
        }
    }
}
