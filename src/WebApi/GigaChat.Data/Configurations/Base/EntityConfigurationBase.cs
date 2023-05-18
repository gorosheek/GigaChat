using GigaChat.Core.Common.Entities.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigaChat.Data.Configurations.Base;

public abstract class EntityConfigurationBase<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase<TId>
    where TId : IEquatable<TId>

{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreatedDate)
            .IsRequired();

        builder.Property(e => e.UpdatedDate)
            .IsRequired();

        OnConfigure(builder);
    }

    public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
}