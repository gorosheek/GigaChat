using GigaChat.Core.Common.Entities.Users;
using GigaChat.Data.Configurations.Base;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigaChat.Data.Configurations;

public class UserConfiguration : EntityConfigurationBase<User, Guid>
{
    public override void OnConfigure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Login)
            .IsRequired();

        builder.Property(u => u.Name)
            .IsRequired();

        builder.Property(u => u.IsDeleted)
            .IsRequired();

        builder.OwnsOne(u => u.Password, b =>
        {
            b.Property(p => p.Hash)
                .IsRequired();

            b.Property(p => p.Salt)
                .IsRequired();
        });
    }
}