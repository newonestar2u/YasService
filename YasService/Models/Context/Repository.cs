namespace YasService.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Extensions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private const int TopCount = 500;

        private readonly DbContext context;

        private readonly DbSet<TEntity> set;

        public Repository()
        {
        }

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int topCount = TopCount)
        {
            return this.AssembleGetListQuery(filter, orderBy).Take(topCount).ToList();
        }

        public async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int topCount = TopCount)
        {
            return await this.AssembleGetListQuery(filter, orderBy).Take(topCount).ToListAsync();
        }

        public IEnumerable<TEntity> GetPaginatedCollection(
            PaginationParams pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = this.AssembleGetListQuery(filter, orderBy);
            pageInfo.TotalRecords = query.Count();

            return query.Paginate(pageInfo).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetPaginatedCollectionAsync(
            PaginationParams pageInfo,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = this.AssembleGetListQuery(filter, orderBy);
            pageInfo.TotalRecords = query.Count();

            return await query.Paginate(pageInfo).ToListAsync();
        }

        public TEntity GetById(object id)
        {
            if (id.GetType().IsArray)
            {
                return this.set.Find(id as object[]);
            }
            else
            {
                return this.set.Find(id);
            }
        }

        public TEntity Insert(TEntity entity)
        {
            return this.set.Add(entity);
        }

        public TEntity Delete(object id)
        {
            TEntity entityToDelete = this.set.Find(id);
            return this.Delete(entityToDelete);
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            TEntity entityToDelete = await this.set.FindAsync(id);
            return entityToDelete == null ? null : this.Delete(entityToDelete);
        }

        public TEntity Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.set.Attach(entityToDelete);
            }

            return this.set.Remove(entityToDelete);
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            this.set.Attach(entityToUpdate);
            var entry = this.context.Entry(entityToUpdate);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await this.set.FindAsync(id);
        }


        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> selector, params string[] includes)
        {
            var q = this.set.Where(selector);
            includes?.ToList().ForEach(i => q = q.Include(i));
            return await q.SingleOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            var q = this.set.Where(selector);

            includes?.ToList().ForEach(i => q = q.Include(i));
            return await q.SingleOrDefaultAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> selector, params Expression<Func<TEntity, object>>[] include)
        {
            var q = this.set.Where(selector);

            include?.ToList().ForEach(i => q = q.Include(i));
            return q.SingleOrDefault();

        }

        public TEntity Find(Expression<Func<TEntity, bool>> selector, params string[] include)
        {
            var q = this.set.Where(selector);

            include?.ToList().ForEach(i => q = q.Include(i));
            return q.SingleOrDefault();
        }

        private IQueryable<TEntity> AssembleGetListQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IQueryable<TEntity> query = orderBy == null ? this.set : orderBy(this.set);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return this.set.Any(filter);
            return this.set.ToList().Count > 0;
        }
    }
}
