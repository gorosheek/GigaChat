using ErrorOr;

using GigaChat.Core.Entities.ChatMessages;

using MediatR;

namespace GigaChat.Core.ChatMessages.Queries.ListChatMessages;

public record ListChatMessagesQuery(long ChatRoomId) : IRequest<ErrorOr<IEnumerable<ChatMessage>>>;