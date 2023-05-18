using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Entities.ChatMessages;

using MediatR;

namespace GigaChat.Core.ChatMessages.Commands.CreateChatMessage;

public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, ErrorOr<Created>>
{
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChatMessageCommandHandler(
        IChatMessageRepository chatMessageRepository,
        IChatRoomRepository chatRoomRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _chatMessageRepository = chatMessageRepository;
        _chatRoomRepository = chatRoomRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Created>> Handle(
        CreateChatMessageCommand request,
        CancellationToken cancellationToken)
    {
        if (!await _chatRoomRepository.ExistsWithIdAsync(request.ChatRoomId))
            throw new NotImplementedException();
        if (!await _userRepository.ExistsWithIdAsync(request.UserId))
            throw new NotImplementedException();

        var chatMessage = new ChatMessage(request.Text, request.ChatRoomId, request.UserId);

        await _chatMessageRepository.InsertAsync(chatMessage, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}