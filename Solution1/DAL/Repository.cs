using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Generic repository implementation for CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BookstoreDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(BookstoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public void Remove(TEntity entity) => _dbSet.Remove(entity);

        public void Update(TEntity entity) => _dbSet.Update(entity);
    }
}
