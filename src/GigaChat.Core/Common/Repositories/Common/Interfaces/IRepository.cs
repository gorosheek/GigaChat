using LinqSpecs;

namespace GigaChat.Core.Common.Repositories.Common.Interfaces;

public interface IRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : IEquatable<TId>
{
    Task<TEntity?> FindOneByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity?> FindOneAsync(Specification<TEntity>? spec = null, CancellationToken cancellationToken = default);
    IAsyncEnumerable<TEntity> FindManyByIds(ICollection<TId> ids);
    IAsyncEnumerable<TEntity> FindMany(Specification<TEntity>? spec = null);
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<bool> ExistsWithIdAsync(TId id, CancellationToken cancellationToken = default);
}