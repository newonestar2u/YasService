namespace YasService.Controllers
{
    using Models;
    using Models.Context;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using YasService.Exceptions;

    public abstract class BaseController<T> : ApiController where T : BaseModel, new()
    {
        protected readonly IUnitOfWork<YasContext> Context;

        protected readonly IRepository<T> Repository;

        protected BaseController(IUnitOfWork<YasContext> context)
        {
            this.Context = context;
            this.Repository = this.Context.GetRepository<T>();
        }

        // GET: api/Base
        public virtual IEnumerable<T> Get()
        {
            return this.Repository.Get();
        }

        // GET: api/Base/5
        public virtual T Get(int id)
        {
            return this.Repository.GetById(id);
        }

        // POST: api/Base
        public virtual T Post(T value)
        {
            var entity = this.Repository.Insert(value);
            this.Context.Save();
            return entity;
        }

        // PUT: api/Base/5
        public virtual T Put(int id, T value)
        {
            var entity = this.Repository.GetById(id);
            value.UpdatedOn = DateTime.Now;
            AutoMapper.Mapper.Initialize(a =>
            {
                a.CreateMissingTypeMaps = true;
                a.CreateMap<T, T>();
            });

            AutoMapper.Mapper.Map(value, entity);
            this.Repository.Update(entity);
            this.Context.Save();
            return entity;
        }

        // DELETE: api/Base/5
        public virtual void Delete(int id)
        {
            var entity = this.Repository.GetById(id);
            if (entity == null)
                throw new NotFoundException("Not found item.");
            this.Repository.Delete(entity);
            this.Context.Save();
        }
    }
}
