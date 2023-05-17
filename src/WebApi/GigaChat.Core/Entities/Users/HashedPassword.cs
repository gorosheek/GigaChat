namespace GigaChat.Core.Entities.Users;

public record HashedPassword(string Hash, byte[] Salt);