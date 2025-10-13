using Domain.Interfaces;
using Models = Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Models.User>, IUserRepository
    {
        public UserRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}