using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfRepositoryBase<T> : IRepositoryBase<T>
        where T : class, IEntity, new()
    {
        protected readonly BudgetControllerDbContext _context;

        private readonly DbSet<T> _dbSet;

        public EfRepositoryBase(BudgetControllerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity) => _dbSet.Add(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges)
            => !trackChanges
            ? _dbSet.AsNoTracking()
            : _dbSet;

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges
            ? _dbSet.Where(expression).AsNoTracking()
            : _dbSet.Where(expression);

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
