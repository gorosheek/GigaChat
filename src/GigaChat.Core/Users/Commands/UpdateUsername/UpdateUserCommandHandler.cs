using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;

using MediatR;

namespace GigaChat.Core.Users.Commands.UpdateUsername;

public class UpdateUsernameCommandHandler : IRequestHandler<UpdateUsernameCommand, ErrorOr<Updated>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsernameCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindOneByIdAsync(request.UserId, cancellationToken);
        if (user is null) throw new NotImplementedException();

        user.Name = request.Name;

        await _userRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}