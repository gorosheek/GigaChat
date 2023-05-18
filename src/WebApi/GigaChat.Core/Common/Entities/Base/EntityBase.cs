using GigaChat.Core.Common.Repositories.Common.Interfaces;

namespace GigaChat.Core.Common.Entities.Base;

public abstract class EntityBase<TId> : IEntity<TId>
    where TId : IEquatable<TId>
{
    public TId? Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}