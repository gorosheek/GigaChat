using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.SoftDeleteChatRoom;

public class SoftDeleteChatRoomCommandHandler : IRequestHandler<SoftDeleteChatRoomCommand, ErrorOr<Deleted>>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SoftDeleteChatRoomCommandHandler(IChatRoomRepository chatRoomRepository, IUnitOfWork unitOfWork)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(SoftDeleteChatRoomCommand request, CancellationToken cancellationToken)
    {
        var chatRoom = await _chatRoomRepository.FindOneByIdAsync(request.ChatRoomId);
        if (chatRoom is null) throw new NotImplementedException();

        chatRoom.IsDeleted = true;

        await _chatRoomRepository.UpdateAsync(chatRoom, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}