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

public class AsyncRepositoryBase<TEntity, TContext, TId> : IAsyncRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TContext : DbContext, new()
{
    protected readonly TContext _context;
    //protected readonly DbSet<TEntity> _dbSet;

    public AsyncRepositoryBase(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        //_dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> Add(TEntity entity)
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

    public async Task<TEntity> Delete(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
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

    public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
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

    public async Task<TEntity> Update(TEntity entity)
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
}
