using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NikahMetromoniApp.DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);

            }
            catch (Exception e)
            {
                throw new Exception("Find by Id Fail. Erro: " + e.Message);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Get All Data Fail. Error: " + e.Message);

            }
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            try
            {
                return Context.Set<TEntity>();

            }
            catch (Exception e)
            {
                throw new Exception("Get All Queryable Data Fail. Error: " + e.Message);

            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate);

            }
            catch (Exception e)
            {
                throw new Exception("Find Data Fail. Error: " + e.Message);

            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().SingleOrDefault(predicate);

            }
            catch (Exception e)
            {
                throw new Exception("Find Single Data Fail. Error: " + e.Message);

            }


        }

        public void Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Data Save Fail. Error: " + e.Message);

            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().AddRange(entities);

            }
            catch (Exception e)
            {
                throw new Exception("Data List Save Fail. Error: " + e.Message);

            }
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Remove(entity);

            }
            catch (Exception e)
            {
                throw new Exception("Data Delete Fail. Error: " + e.Message);

            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(entities);

            }
            catch (Exception e)
            {
                throw new Exception("Data List Delete Fail. Error: " + e.Message);

            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}