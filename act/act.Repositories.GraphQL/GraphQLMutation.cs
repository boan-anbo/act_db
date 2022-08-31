using act.Repositories.Db;
using act.Repositories.Interface;
using act.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace act.Repositories.GraphQL;

public class GraphQLMutation
{
    public async Task<Interaction?> AddNewEntityInteraction(
        [Service(ServiceKind.Synchronized)] IInteractionRepository _repo,
        String label
    )
    {
        var interaction = Interaction.FromLabel(label);
        interaction.SetEntityIdentityAndType();
        await _repo.AddInteraction(interaction);
        

        return await _repo.GetInteractionScalar(interaction.Id);
    }
    
    public async Task<int> DeleteInteraction(
        int id,
        [Service(ServiceKind.Synchronized)] IInteractionRepository _repo
    )
    {
        await _repo.DeleteInteraction(id);
        return Task.FromResult(id).Result;
    }
}