using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class UserRepository : AsyncRepositoryBase<User, TobetoBootCampProjectContext, int>, IUserRepository
{

    //protected TobetoBootCampProjectContext _context;
    //protected readonly DbSet<User> _dbSet;

    //public UserRepository(TobetoBootCampProjectContext context, DbSet<User> dbSet)
    //{
    //    _context = context;
    //    _dbSet = dbSet;
    //}

    //public async Task<User> Add(User entity)
    //{
    //    _context.Add(entity);
    //    await _context.SaveChangesAsync();
    //    return entity;
    //}

    //public async Task<User> Delete(User entity)
    //{
    //    _context.Remove(entity);
    //    await _context.SaveChangesAsync();
    //    return entity;
    //}

    //public async Task<User> Get(Expression<Func<User, bool>> predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
    //{
    //    IQueryable<User> query = _dbSet;

    //    if (predicate != null)
    //    {
    //        query = query.Where(predicate);
    //    }

    //    if (include != null)
    //    {
    //        query = include(query);
    //    }

    //    return await query.FirstOrDefaultAsync();
    //}

    //public async Task<List<User>> GetAll(Expression<Func<User, bool>> predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
    //{
    //    IQueryable<User> query = _dbSet;

    //    if (predicate != null)
    //    {
    //        query = query.Where(predicate);
    //    }

    //    if (include != null)
    //    {
    //        query = include(query);
    //    }

    //    return await query.ToListAsync();
    //}

    //public IQueryable<User> Query()
    //{
    //    return _dbSet.AsQueryable();
    //}

    //public async Task<User> Update(User entity)
    //{
    //    _context.Entry(entity).State = EntityState.Modified;
    //    await _context.SaveChangesAsync();
    //    return entity;
    //}
    public UserRepository(TobetoBootCampProjectContext context) : base(context)
    {
    }
}
