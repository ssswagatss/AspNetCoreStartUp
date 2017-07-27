using Demo.DAL.Interfaces;
using Demo.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Demo.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;
        protected IGenericRepository<T> Repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }
        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }
        public void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Repository.Edit(entity);
        }

    }
}
