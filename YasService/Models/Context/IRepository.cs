
namespace YasService.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int topCount = 500
            );

        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int topCount = 25);

        IEnumerable<TEntity> GetPaginatedCollection(
            PaginationParams pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IEnumerable<TEntity>> GetPaginatedCollectionAsync(
            PaginationParams pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(object id);

        bool Any(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetByIdAsync(object id);

        TEntity Insert(TEntity entity);

        TEntity Delete(object id);

        Task<TEntity> DeleteAsync(object id);

        TEntity Delete(TEntity entityToDelete);

        TEntity Update(TEntity entityToUpdate);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> selector, params Expression<Func<TEntity, object>>[] include);


        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> selector, params string[] include);

        TEntity Find(Expression<Func<TEntity, bool>> selector, params Expression<Func<TEntity, object>>[] include);

        TEntity Find(Expression<Func<TEntity, bool>> selector, params string[] include);
    }
}