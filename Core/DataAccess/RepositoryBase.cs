using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Core.DataAccess;

public class RepositoryBase<TEntity, TContext, TId> : IAsyncRepository<TEntity, TId>,IRepository<TEntity,TId>
    where TEntity : BaseEntity<TId>
    where TContext : DbContext, new()
{
    protected readonly TContext _context;
    //protected readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        //_dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            entity.CreateDate = DateTime.Now; //created date added.
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> SoftDeleteAsync(TEntity entity)
    {
        entity.DeleteDate = DateTime.UtcNow;
        entity.IsDeleted = true;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = Query();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (include != null)
        {
            query = include(query);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = Query();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (include != null)
        {
            query = include(query);
        }

        return await query.ToListAsync();
    }

    public IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            entity.UpdateDate = DateTime.UtcNow; //update date time enter
            var UpdatedEntity = _context.Entry(entity);
            UpdatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {

            throw e;
        }

        //_context.Entry(entity).State = EntityState.Modified;
        //await _context.SaveChangesAsync();
        return entity;
    }


    //
    //  
    //SYNC REPOS
    //


    public TEntity Add(TEntity entity)
    {
        entity.CreateDate = DateTime.UtcNow;
        _context.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        entity.DeleteDate = DateTime.UtcNow;
        _context.Remove(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity SoftDelete(TEntity entity)
    {
        entity.DeleteDate = DateTime.UtcNow;
        entity.IsDeleted = true;
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return queryable.ToList();
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateDate = DateTime.UtcNow;
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
