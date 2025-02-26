using Microsoft.EntityFrameworkCore;
using SohaNotebook.Data;
using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger logger) : base(context, logger)
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
                _logger.LogError(ex, "{Repo} Chức năng All đã tạo ra một lỗi", typeof(UserRepository));
                return new List<User>();
            }
        }
    }
}
