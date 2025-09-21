using DataAccess.Interfaces;
using Models = DataAccess.Data;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Models.user>, IUserRepository
    {
        public UserRepository(Models.AppDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}