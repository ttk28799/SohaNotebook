using SohaNotebook.DbSet.IConfiguration;
using SohaNotebook.DbSet.IRepository;
using SohaNotebook.DbSet.Repository;

namespace SohaNotebook.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public IUsersRepository Users { get; private set; }
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Users = new UsersRepository(context, _logger);
        }

        public IUsersRepository UserRepository => throw new NotImplementedException();

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
