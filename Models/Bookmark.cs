using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Models
{
    public partial class Bookmark
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [Url]
        [StringLength(1000)]
        public string Link { get; set; } = null!;

        public Category? Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastViewedDate { get; set; }
    }
}
