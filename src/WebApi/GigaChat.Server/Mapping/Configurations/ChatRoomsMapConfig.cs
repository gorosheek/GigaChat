using GigaChat.Contracts.Http.ChatRooms.Requests;
using GigaChat.Contracts.Http.ChatRooms.Responses;
using GigaChat.Core.ChatRooms.Commands.CreateChatRoom;
using GigaChat.Core.ChatRooms.Commands.SoftDeleteChatRoom;
using GigaChat.Core.ChatRooms.Commands.UpdateChatRoomTitle;
using GigaChat.Core.Common.Entities.ChatRooms;

using Mapster;

namespace GigaChat.Server.Mapping.Configurations;

public class ChatRoomsMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChatRoom, ChatRoomResponse>();
        config.NewConfig<CreateChatRoomRequest, CreateChatRoomCommand>();
        config.NewConfig<UpdateChatRoomTitleRequest, UpdateChatRoomTitleCommand>();
        config.NewConfig<SoftDeleteChatRoomRequest, SoftDeleteChatRoomCommand>();
    }
}