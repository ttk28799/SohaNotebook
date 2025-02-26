using SohaNotebook.DbSet.IRepository;

namespace SohaNotebook.DbSet.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
    }
}
