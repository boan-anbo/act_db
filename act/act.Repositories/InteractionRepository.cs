using act.Repositories.Db;
using act.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace act.Repositories.Interface;

public class InteractionRepository : IInteractionRepository
{
    private readonly ActDbContext _context;

    public InteractionRepository(ActDbContext context)
        => _context = context;
    
    public async Task<Interaction> GetInteractionScalar(int id)
    {
        return await _context.Interactions
            .Include(x => x.Type)
            
            .FirstOrDefaultAsync(i => i.Id == id) ?? throw new InvalidOperationException();
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

    public async Task DeleteInteraction(int id)
    {
        var interaction = await _context.Interactions.FindAsync(id);
        _context.Interactions.Remove(interaction);
        await SaveChanges();
    }
}