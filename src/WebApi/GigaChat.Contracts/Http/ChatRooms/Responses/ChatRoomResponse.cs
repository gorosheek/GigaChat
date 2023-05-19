using GigaChat.Contracts.Http.Users.Responses;

namespace GigaChat.Contracts.Http.ChatRooms.Responses;

public record ChatRoomResponse(long Id, string Title, ICollection<UserResponse> Users);