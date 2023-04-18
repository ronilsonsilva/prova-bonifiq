using System.Linq.Expressions;

namespace ProvaPub.Repository
{
    public interface IRepository<TEntity, TList> 
    {
        Task<TEntity> Add(TEntity entity);
        Task AddRange(IList<TEntity> entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Get(int id);
        Task<TList> List(int page);
        Task<int> Count(Expression<Func<TEntity, bool>> expression);
    }
}
