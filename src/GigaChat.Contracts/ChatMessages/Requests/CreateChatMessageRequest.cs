using System;
namespace GigaChat.Contracts.ChatMessages.Requests;

public record CreateChatMessageRequest(string Text, long ChatRoomId, Guid UserId);