using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Represents a category for books.
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
