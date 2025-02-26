using SohaNotebook.DbSet.IRepository;
using SohaNotebook.DbSet.Repository;

namespace SohaNotebook.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Users = new UserRepository(_context, _logger);
        }
        public IUserRepository Users { get; private set; }
    }
}
