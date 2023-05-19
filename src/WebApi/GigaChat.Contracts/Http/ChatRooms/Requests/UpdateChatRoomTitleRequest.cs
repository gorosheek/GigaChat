namespace GigaChat.Contracts.Http.ChatRooms.Requests;

public record UpdateChatRoomTitleRequest(long ChatRoomId, string Title);