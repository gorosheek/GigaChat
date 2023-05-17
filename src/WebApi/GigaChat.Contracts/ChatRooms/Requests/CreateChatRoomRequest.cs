namespace GigaChat.Contracts.ChatRooms.Requests;

public record CreateChatRoomRequest(string Title, ICollection<Guid> UserIds);