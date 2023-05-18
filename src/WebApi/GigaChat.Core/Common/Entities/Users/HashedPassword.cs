namespace GigaChat.Core.Common.Entities.Users;

public record HashedPassword(string Hash, byte[] Salt);