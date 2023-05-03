namespace GigaChat.Core.Common.Repositories.Common.Interfaces;

public interface IEntity<out TId> where TId : IEquatable<TId>
{ 
    TId? Id { get; }
}