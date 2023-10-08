using System.Linq.Expressions;
using ApiPractice.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Infrastructure;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly UniversityManagementContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(UniversityManagementContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, CancellationToken cancellationToken = default,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (expression != null)
            query = query.Where(expression);

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, 
                     StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        if (orderBy != null)
            return await orderBy(query).ToListAsync(cancellationToken);

        return await query.ToListAsync(cancellationToken);
    }

    
    
    public async Task<TEntity> Get(Expression<Func<TEntity, bool>>? expression, 
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<TEntity> FindById(object id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Remove(TEntity entity)
    {
        if (_dbContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}