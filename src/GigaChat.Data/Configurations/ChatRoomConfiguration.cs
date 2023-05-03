using GigaChat.Core.Entities.ChatRooms;
using GigaChat.Data.Configurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigaChat.Data.Configurations;

public class ChatRoomConfiguration : EntityConfigurationBase<ChatRoom, long>
{
    public override void OnConfigure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.Property(r => r.Title)
            .IsRequired();

        builder.Property(r => r.IsDeleted)
            .IsRequired();

        builder.HasMany(r => r.Users)
            .WithMany();

        builder.Navigation(r => r.Users).AutoInclude();
    }
}