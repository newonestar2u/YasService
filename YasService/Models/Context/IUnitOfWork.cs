namespace YasService.Models.Context
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseModel, new();

        long GetNextSequence(string prefix);

        void Save();

        Task SaveAsync();
    }

    public interface IUnitOfWork<TDataContext> : IUnitOfWork
    {
    }
}