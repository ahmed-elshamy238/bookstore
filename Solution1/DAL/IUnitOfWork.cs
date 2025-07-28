using System;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Unit of Work interface for managing transactions.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Category> Categories { get; }
        IRepository<User> Users { get; }
        IRepository<Favorite> Favorites { get; }
        IRepository<Review> Reviews { get; }
        Task<int> SaveChangesAsync();
    }
}
