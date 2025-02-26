using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.IConfiguration
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        Task CompleteAsync();
    }
}
