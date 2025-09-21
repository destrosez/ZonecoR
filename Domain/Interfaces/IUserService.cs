using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<user>> GetAll();
        Task<user?> GetById(int id);
        Task Create(user model);
        Task Update(user model);
        Task Delete(int id);
    }
}