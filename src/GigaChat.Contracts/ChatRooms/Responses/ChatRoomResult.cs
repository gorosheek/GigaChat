using GigaChat.Contracts.Users.Responses;

namespace GigaChat.Contracts.ChatRooms.Responses;

public record ChatRoomResponse(long Id, string Title, ICollection<UserResponse> Users);