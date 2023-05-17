namespace GigaChat.Contracts.ChatRooms.Requests;

public record UpdateChatRoomTitleRequest(long ChatRoomId, string Title);