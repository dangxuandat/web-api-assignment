using Cinema.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.Repository.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private RepositoryContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(RepositoryContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity deletedEntity)
        {
            if(_context.Entry(deletedEntity).State == EntityState.Detached)
            {
                _dbSet.Attach(deletedEntity);
            }
            _dbSet.Remove(deletedEntity);
        }

        public void DeleteById(Guid id)
        {
            TEntity deletedEntity = _dbSet.Find(id);
            Delete(deletedEntity);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includedProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            
            foreach(String includedProperty in includedProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includedProperty);
            }
            
            if(orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity newEntity)
        {
            _dbSet.Add(newEntity);
        }

        public void Update(TEntity updatedEntity)
        {
            _dbSet.Attach(updatedEntity);
            _context.Entry(updatedEntity).State = EntityState.Modified;
        }
    }
}
