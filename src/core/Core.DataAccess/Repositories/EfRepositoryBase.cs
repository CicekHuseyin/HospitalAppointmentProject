using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public abstract class EfRepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId>, IAsyncRepository<TEntity, TId>
        where TEntity : Entity<TId>
    where TContext : DbContext
    {
        protected TContext Context { get; }

        protected EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedTime=DateTime.UtcNow;
            Context.Entry(entity).State=EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedTime = DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public bool Any(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true)
        {
            IQueryable<TEntity> query = Query();

            if (enableTracking is false)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                return query.Any(filter);
            }
            return query.Any();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Query();

            if (enableTracking is false)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                return await query.AnyAsync(filter);
            }
            return await query.AnyAsync();
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true)
        {
            IQueryable<TEntity> query = Query();
            if (include is false)
            {
                query = query.IgnoreAutoIncludes();
            }
            if (enableTracking is false)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (enableTracking == false)
            {
                query = query.AsNoTracking();
            }

            if (include is false)
            {
                query = query.IgnoreAutoIncludes();
            }
            return query.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (enableTracking == false)
            {
                query = query.AsNoTracking();
            }

            if (include is false)
            {
                query = query.IgnoreAutoIncludes();
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity>? GetAsync(Expression<Func<TEntity, bool>> filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Query();
            if (include is false)
            {
                query = query.IgnoreAutoIncludes();
            }
            if (enableTracking is false)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public TEntity? GetById(TId id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedTime = DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedTime = DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Query();

            if (enableTracking is false)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                return await query.CountAsync(filter, cancellationToken);
            }

            return await query.CountAsync(cancellationToken);
        }
    }
}
