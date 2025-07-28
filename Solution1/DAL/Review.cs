using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Represents a review and rating for a book by a user.
    /// </summary>
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1-5
    }
}
