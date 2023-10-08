using System.Linq.Expressions;

namespace ApiPractice.Domain;

public interface IGenericRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Get a list of an entity
    /// </summary>
    /// <param name="expression">condition, filter for the LINQ query</param>
    /// <param name="orderBy">sort based on a column</param>
    /// <param name="cancellationToken"></param>
    /// <param name="includeProperties">add properties whether there has a relationship of two or more tables</param>
    /// <returns>the list of an entity</returns>
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
        CancellationToken cancellationToken = default,
        string includeProperties = "");

    Task<TEntity> Get(Expression<Func<TEntity, bool>>? expression, CancellationToken cancellationToken = default);

    Task<TEntity> FindById(object id, CancellationToken cancellationToken = default);

    Task Add(TEntity entity, CancellationToken cancellationToken = default);

    void Remove(TEntity entity);

    void Update(TEntity entity);
}