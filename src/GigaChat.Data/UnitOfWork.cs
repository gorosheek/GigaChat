using GigaChat.Core.Common.Repositories.Common.Interfaces;

namespace GigaChat.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly GigaChatDbContext _context;
    
    public UnitOfWork(GigaChatDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}