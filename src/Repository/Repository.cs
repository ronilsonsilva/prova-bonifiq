using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using System.Linq.Expressions;

namespace ProvaPub.Repository
{

    public class Repository<TEntity, TList> : IRepository<TEntity, TList> where TEntity : BaseEntity where TList : BaseList<TEntity>
    {
        protected readonly TestDbContext _context;

        public Repository(TestDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TList> List(int page)
        {
            if (page <= 0) throw new InvalidOperationException($"Page deve ser maior que 0");

            var list = await _context.Set<TEntity>().Skip((page - 1) * 10).Take(10).ToListAsync();
            var mappedList = Activator.CreateInstance<TList>();
            mappedList.Data = list;
            mappedList.CurrentPage = page;
            mappedList.TotalCount = _context.Set<TEntity>().Count();
            return mappedList;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            var entity = await this.Get(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public virtual async Task<IList<TEntity>> Get()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entityRemover = await this.Get(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }

        public virtual async Task AddRange(IList<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> expression)
        {
            return await Get(expression).CountAsync();
        }
    }
}
