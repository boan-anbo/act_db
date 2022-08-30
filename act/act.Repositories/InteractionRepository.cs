using act.Repositories.Db;
using act.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace act.Repositories.Interface;

public class InteractionRepository : IInteractionRepository
{
    private readonly ActDbContext _context;

    public InteractionRepository(ActDbContext context)
        => _context = context;
    
    public async Task<Interaction> GetInteraction(int id)
    {
        return await _context.Interactions.FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<IEnumerable<Interaction>> GetAllInteractions()
    {
        throw new NotImplementedException();
    }

    public async Task<Interaction> AddInteraction(Interaction interaction)
    {
        // Add interaction to database
        _context.Interactions.Add(interaction);
        await SaveChanges();
        return interaction;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}