

using act.Services.Model;

namespace act.Repositories.Interface;

public interface IInteractionRepository
{
    Task<Interaction> GetInteraction(int id);
    Task<IEnumerable<Interaction>> GetAllInteractions();
    Task<Interaction> AddInteraction(Interaction interaction);
    Task SaveChanges();
}