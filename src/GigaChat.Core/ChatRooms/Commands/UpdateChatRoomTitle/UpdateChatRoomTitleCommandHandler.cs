using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.UpdateChatRoomTitle;

public class UpdateChatRoomTitleCommandHandler : IRequestHandler<UpdateChatRoomTitleCommand, ErrorOr<Updated>>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChatRoomTitleCommandHandler(IChatRoomRepository chatRoomRepository, IUnitOfWork unitOfWork)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateChatRoomTitleCommand request, CancellationToken cancellationToken)
    {
        var chatRoom = await _chatRoomRepository.FindOneByIdAsync(request.ChatRoomId);
        if (chatRoom is null) throw new NotImplementedException();

        chatRoom.Title = request.Title;

        await _chatRoomRepository.UpdateAsync(chatRoom, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}