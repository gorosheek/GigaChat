using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;

using MediatR;

namespace GigaChat.Core.Users.Commands.SoftDeleteUser;

public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, ErrorOr<Deleted>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SoftDeleteUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindOneByIdAsync(request.UserId, cancellationToken);
        if (user is null) throw new NotImplementedException(); //TODO

        user.IsDeleted = true;

        await _userRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}