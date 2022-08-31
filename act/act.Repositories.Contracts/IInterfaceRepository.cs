

using act.Services.Model;

namespace act.Repositories.Interface;

public interface IInteractionRepository
{
    Task<Interaction> GetInteractionScalar(int id);
    Task<IEnumerable<Interaction>> GetAllInteractions();
    Task<Interaction> AddInteraction(Interaction interaction);
    Task SaveChanges();
    Task DeleteInteraction(int id);
}