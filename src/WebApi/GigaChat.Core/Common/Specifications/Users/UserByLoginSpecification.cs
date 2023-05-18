using System.Linq.Expressions;

using GigaChat.Core.Common.Entities.Users;

using LinqSpecs;

namespace GigaChat.Core.Common.Specifications.Users;

public class UserByLoginSpecification : Specification<User>
{
    private readonly string _userLogin;

    public UserByLoginSpecification(string userLogin)
    {
        _userLogin = userLogin;
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Login == _userLogin;
    }
}