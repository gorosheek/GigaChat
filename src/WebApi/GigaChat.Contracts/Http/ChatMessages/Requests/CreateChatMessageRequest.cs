namespace GigaChat.Contracts.Http.ChatMessages.Requests;

public record CreateChatMessageRequest(string Text, long ChatRoomId, Guid UserId);