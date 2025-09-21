using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Models = DataAccess.Data;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;

        public UserService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public Task<List<Models.user>> GetAll()
        {
            return _repo.User.FindAll().ToListAsync();
        }

        public Task<Models.user?> GetById(int id)
        {
            var entity = _repo.User.FindByCondition(x => x.id == id).FirstOrDefault();
            return Task.FromResult(entity);
        }

        public Task Create(Models.user model)
        {
            _repo.User.Create(model);
            _repo.Save();
            return Task.CompletedTask;
        }

        public Task Update(Models.user model)
        {
            _repo.User.Update(model);
            _repo.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var entity = _repo.User.FindByCondition(x => x.id == id).FirstOrDefault();
            if (entity != null)
            {
                _repo.User.Delete(entity);
                _repo.Save();
            }
            return Task.CompletedTask;
        }
    }
}