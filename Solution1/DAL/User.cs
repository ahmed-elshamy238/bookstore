using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Represents a user in the bookstore system.
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
