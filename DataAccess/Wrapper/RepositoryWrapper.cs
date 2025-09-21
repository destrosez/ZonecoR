using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _ctx;
        private IUserRepository? _user;

        public RepositoryWrapper(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_ctx);
                }

                return _user;
            }
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}