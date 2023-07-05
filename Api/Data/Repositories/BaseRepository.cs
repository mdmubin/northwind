using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class BaseRepository<T> : IRepository<T>
    where T : class
{
    private readonly NorthwindContext _context;

    protected BaseRepository(NorthwindContext context)
    {
        _context = context;
    }


    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return trackChanges ? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void CreateAll(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteAll(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}