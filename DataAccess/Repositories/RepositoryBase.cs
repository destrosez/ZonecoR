using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext RepositoryContext { get; }

        protected RepositoryBase(AppDbContext context)
        {
            RepositoryContext = context;
        }

        public async Task<List<T>> FindAll()
        {
            return await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task Create(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
        }

        public Task Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}