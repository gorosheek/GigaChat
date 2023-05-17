using GigaChat.Contracts.ChatMessages.Requests;
using GigaChat.Contracts.ChatMessages.Responses;
using GigaChat.Core.ChatMessages.Commands.CreateChatMessage;
using GigaChat.Core.ChatMessages.Queries.ListChatMessages;
using GigaChat.Core.Entities.ChatMessages;

using Mapster;

namespace GigaChat.Server.Mapping.Configurations;

public class ChatMessagesMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChatMessage, ChatMessageResponse>();
        config.NewConfig<CreateChatMessageRequest, CreateChatMessageCommand>();
        config.NewConfig<ListChatMessagesRequest, ListChatMessagesQuery>();
    }
}