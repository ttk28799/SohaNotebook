using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.IConfiguration
{
    public interface IUnitOfWork
    {
        IUsersRepository UserRepository { get; }
        Task CompleteAsync();
    }
}
