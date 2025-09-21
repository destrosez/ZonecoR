using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _repoContext;
        private IUserRepository _user;

        public RepositoryWrapper(AppDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}