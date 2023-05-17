using GigaChat.Core.Entities.Base;
using GigaChat.Core.Entities.Users;

namespace GigaChat.Core.Entities.ChatRooms;

public class ChatRoom : EntityBase<long>
{
    private ChatRoom()
    {
        Title = null!;
        Users = null!;
    }

    public ChatRoom(string title)
    {
        Title = title;
        Users = new List<User>();
    }

    public bool IsDeleted { get; set; }
    public string Title { get; set; }
    public ICollection<User> Users { get; set; }
}