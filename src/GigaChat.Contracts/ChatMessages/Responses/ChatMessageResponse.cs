namespace GigaChat.Contracts.ChatMessages.Responses;

public record ChatMessageResponse(long Id, string Text, long ChatRoomId, Guid UserId);