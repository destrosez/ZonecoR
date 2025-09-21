using Domain.Interfaces;
using Models = Domain.Models;

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