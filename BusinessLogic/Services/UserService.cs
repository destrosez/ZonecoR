using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;

        public UserService(IRepositoryWrapper repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<List<User>> GetAll()
        {
            return await _repo.User.FindAll();
        }

        public async Task<User?> GetById(int id)
        {
            var list = await _repo.User.FindByCondition(x => x.id == id);
            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        public async Task Create(User model)
        {
            ValidateUserForCreate(model);

            await _repo.User.Create(model);
            await _repo.Save();
        }

        public async Task Update(User model)
        {
            ValidateUserForUpdate(model);

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


        private static void ValidateUserForCreate(User model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(model.username))
                throw new ArgumentException("Username is required.", nameof(model.username));

            if (string.IsNullOrWhiteSpace(model.email))
                throw new ArgumentException("Email is required.", nameof(model.email));

            if (string.IsNullOrWhiteSpace(model.password_hash))
                throw new ArgumentException("Password hash is required.", nameof(model.password_hash));

            if (model.username.Length < 3)
                throw new ArgumentException("Username is too short.", nameof(model.username));
        }

        private static void ValidateUserForUpdate(User model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (model.id <= 0)
                throw new ArgumentException("Id must be a positive number for update.", nameof(model.id));

            if (string.IsNullOrWhiteSpace(model.username))
                throw new ArgumentException("Username is required.", nameof(model.username));

            if (string.IsNullOrWhiteSpace(model.email))
                throw new ArgumentException("Email is required.", nameof(model.email));
        }
    }
}
