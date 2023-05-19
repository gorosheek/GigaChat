namespace GigaChat.Contracts.Http.ChatRooms.Requests;

public record CreateChatRoomRequest(string Title, ICollection<Guid> UserIds);