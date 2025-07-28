using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Unit of Work implementation for managing repositories and transactions.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookstoreDbContext _context;
        public IRepository<Book> Books { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<User> Users { get; }
        public IRepository<Favorite> Favorites { get; }
        public IRepository<Review> Reviews { get; }

        public UnitOfWork(BookstoreDbContext context)
        {
            _context = context;
            Books = new Repository<Book>(context);
            Categories = new Repository<Category>(context);
            Users = new Repository<User>(context);
            Favorites = new Repository<Favorite>(context);
            Reviews = new Repository<Review>(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
