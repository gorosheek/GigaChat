using GigaChat.Core.Entities.Base;

namespace GigaChat.Core.Entities.Users;

public class User : EntityBase<Guid>
{
    private User()
    {
        Name = null!;
        Login = null!;
        Password = null!;
    }
    
    public User(string name, string login, HashedPassword password)
    {
        Name = name;
        Login = login;
        Password = password;
    }
    
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public HashedPassword Password { get; set; }
}