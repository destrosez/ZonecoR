namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task Save();
    }
}