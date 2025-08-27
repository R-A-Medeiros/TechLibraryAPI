using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class LogActionRepository : ILogActionRepository
{
    private readonly TechLibraryDbContext _context;

    public LogActionRepository(TechLibraryDbContext context)
    {
        _context = context;
    }
    public async Task Add(LogAction log)
    {
        await _context.Logs.AddAsync(log);
    }

    public async Task<List<LogAction>> GetAllAsync(int skip = 0, int take = 100)
    {
        return await _context.Logs
        .OrderByDescending(l => l.CreatedAt)
        .Skip(skip)
        .Take(take)
        .ToListAsync();
    }
}
