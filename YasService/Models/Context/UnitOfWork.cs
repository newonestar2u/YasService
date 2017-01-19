namespace YasService.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// A list of repositories that have been instantiated in this UoW.
        /// </summary>
        private readonly List<IRepository> repositories = new List<IRepository>();

        protected readonly DbContext Context;// = new ITServicesDataContext(ITServicesConfiguration.ConnectionString);

        private bool disposed;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseModel, new()
        {
            var lockObject = new object();
            if (this.repositories.SingleOrDefault(c => c is IRepository<T>) == null)
            {
                lock (lockObject)
                {
                    if (this.repositories.SingleOrDefault(c => c is IRepository<T>) == null)
                    {
                        this.repositories.Add(new Repository<T>(this.Context));
                    }
                }
            }

            return this.repositories.Single(c => c is IRepository<T>) as IRepository<T>;
        }

        public long GetNextSequence(string prefix)
        {
            return this.Context.Database.SqlQuery<long>("SELECT NEXT VALUE FOR SequenceGenerator." + prefix.Trim()).FirstOrDefault();
        }
        public void Save()
        {
            this.Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }

            this.disposed = true;
        }
    }

    public class UnitOfWork<TDataContext> : UnitOfWork, IUnitOfWork<TDataContext> where TDataContext : DbContext
    {
        public UnitOfWork(TDataContext context)
            : base(context)
        {
        }
    }
}