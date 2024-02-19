using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ShopDBcontext _context;
        internal DbSet<TEntity> dbSet;
        public Repository(ShopDBcontext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToListAsync();
            }
            else
            {
                return query.ToListAsync();
            }
        }
        public async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
			await Save();
		}
        public async Task Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);
            await Save();
        }
        public async Task Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
			await Save();
		}
        public async Task Update(TEntity entityToUpdate)
        {
            await Task.Run
                (
                () =>
                {
                    dbSet.Attach(entityToUpdate);
                    _context.Entry(entityToUpdate).State = EntityState.Modified;
                });
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
