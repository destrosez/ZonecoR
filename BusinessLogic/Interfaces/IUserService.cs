using System.Collections.Generic;
using System.Threading.Tasks;
using Models = DataAccess.Data;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<Models.user>> GetAll();
        Task<Models.user?> GetById(int id);
        Task Create(Models.user model);
        Task Update(Models.user model);
        Task Delete(int id);
    }
}