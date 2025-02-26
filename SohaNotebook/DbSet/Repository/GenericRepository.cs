using Microsoft.EntityFrameworkCore;
using SohaNotebook.Data;
using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<bool> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public Task<bool> DeleteAsync(Guid id, string userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
