using System.Linq.Expressions;

using GigaChat.Core.Common.Entities.Users;

using LinqSpecs;

namespace GigaChat.Core.Common.Specifications.Users;

public class NotDeletedUsersSpec : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => !user.IsDeleted;
    }
}