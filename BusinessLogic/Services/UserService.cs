using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;

        public UserService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public async Task<List<user>> GetAll()
        {
            return await _repo.User.FindAll();
        }

        public async Task<user?> GetById(int id)
        {
            var list = await _repo.User.FindByCondition(x => x.id == id);
            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        public async Task Create(user model)
        {
            await _repo.User.Create(model);
            await _repo.Save();
        }

        public async Task Update(user model)
        {
            await _repo.User.Update(model);
            await _repo.Save();
        }

        public async Task Delete(int id)
        {
            var list = await _repo.User.FindByCondition(x => x.id == id);
            if (list.Count == 0)
            {
                return;
            }

            await _repo.User.Delete(list[0]);
            await _repo.Save();
        }
    }
}