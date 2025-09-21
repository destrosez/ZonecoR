using DataAccess.Interfaces;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}