using ErrorOr;

using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Entities.Users;

using MediatR;

namespace GigaChat.Core.Users.Commands.Registration;

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, ErrorOr<Created>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashProvider _hashProvider;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrationCommandHandler(
        IUserRepository userRepository,
        IPasswordHashProvider hashProvider,
        IUnitOfWork unitOfWork)
    {
        _hashProvider = hashProvider;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Created>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _hashProvider.GetHash(request.Password);
        var user = new User(request.Name, request.Login, hashedPassword);

        await _userRepository.InsertAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}