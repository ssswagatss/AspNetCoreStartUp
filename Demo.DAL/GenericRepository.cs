using Demo.DAL.Interfaces;
using Demo.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DemoContext Context;
        protected DbSet<T> DbSet;
        public GenericRepository(DemoContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = DbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return DbSet.Count();
            }
            else
            {
                return DbSet.Count(predicate);
            }
        }

        public virtual IEnumerable<T> FindWithInclude(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? skip = null, int? take = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                var skipValue = skip.Value;
                query = query.Skip(skipValue);
            }
            if (take.HasValue)
            {
                var takeValue = take.Value;
                query = query.Take(takeValue);
            }
            return query.AsEnumerable();
        }


        public virtual T FirstOrDefault(
           Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            if (filter == null)
            {
                return query.FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault(filter);
            }
        }

        public virtual T FirstOrDefaultWithInclude(
           Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter == null)
            {
                return query.FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault(filter);
            }
        }



        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            DbSet.Remove(entity);
            return entity;
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
