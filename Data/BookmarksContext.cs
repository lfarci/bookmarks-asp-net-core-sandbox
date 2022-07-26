using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookmarksWebApp.Models;

namespace BookmarksWebApp.Data
{
    public class BookmarksContext : DbContext
    {
        public BookmarksContext (DbContextOptions<BookmarksContext> options)
            : base(options)
        {
        }

        public DbSet<BookmarksWebApp.Models.Bookmark> Bookmark { get; set; } = default!;
    }
}
