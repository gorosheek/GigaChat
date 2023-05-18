using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Entities.ChatRooms;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.CreateChatRoom;

public class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, ErrorOr<Created>>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChatRoomCommandHandler(
        IChatRoomRepository chatRoomRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
    {
        var uniqueUserIds = request.UserIds.Distinct().ToList();

        var users = await _userRepository.FindManyByIds(uniqueUserIds)
            .ToListAsync(cancellationToken);

        var chatRoom = new ChatRoom(request.Title)
        {
            Users = users
        };

        await _chatRoomRepository.InsertAsync(chatRoom, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}