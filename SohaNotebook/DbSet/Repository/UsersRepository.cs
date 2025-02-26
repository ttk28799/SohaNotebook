using Microsoft.EntityFrameworkCore;
using SohaNotebook.Data;
using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.Repository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} function GetAllAsync return an error", typeof(UsersRepository));
                return new List<User>();
            }
        }
    }
}
