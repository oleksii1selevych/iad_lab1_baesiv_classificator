using BaesovClassificator.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaesovClassificator.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext DataContext { get; set; }
        public RepositoryBase(DataContext context)
        {
            DataContext = context;
        }

        public void Create(T entity) => DataContext.Set<T>().Add(entity);

        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => DataContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => DataContext.Set<T>().Where(expression).AsNoTracking();

        public void Update(T entity) => DataContext.Set<T>().Update(entity);
    }
}
