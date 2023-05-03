using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Entities.Base;

using LinqSpecs;

using Microsoft.EntityFrameworkCore;

namespace GigaChat.Data.Repositories.Common.Base;

public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : EntityBase<TId>
    where TId : IEquatable<TId>
{
    protected readonly IDateTimeProvider _dateTimeProvider;
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected RepositoryBase(DbContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<TEntity?> FindOneByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id!.Equals(id), cancellationToken);
    }

    public async Task<TEntity?> FindOneAsync(Specification<TEntity>? spec = null, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();
        if (spec != null) query = query.Where(spec);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public IAsyncEnumerable<TEntity> FindManyByIds(ICollection<TId> ids)
    {
        return _dbSet.Where(e => ids.Contains(e.Id!)).AsAsyncEnumerable();
    }

    public IAsyncEnumerable<TEntity> FindMany(Specification<TEntity>? spec = null)
    {
        var query = _dbSet.AsQueryable();
        if (spec != null) query = query.Where(spec);
        return query.AsAsyncEnumerable();
    }

    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var currentTime = await _dateTimeProvider.GetUtcNowAsync();
        entity.CreatedDate = currentTime;
        entity.UpdatedDate = currentTime;
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDate = await _dateTimeProvider.GetUtcNowAsync();
        _dbSet.Update(entity);
    }

    public async Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        await _dbSet.Where(e => e.Id!.Equals(id)).ExecuteDeleteAsync(cancellationToken);
    }

    public IAsyncEnumerable<TEntity> GetAllAsync()
    {
        return _dbSet.AsAsyncEnumerable();
    }

    public async Task<bool> ExistsWithIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(e => e.Id!.Equals(id), cancellationToken);
    }
}