using System;
using System.Threading.Tasks;
using act.Services.Model;

namespace act.Services.Contracts
{
    public interface IInteractionService
    {
        Task<Interaction> CreateAsync(Interaction interaction);


        Task<Interaction> CreateInteraction(String description);

        Task<bool> UpdateAsync(Interaction interaction);

        Task<bool> DeleteAsync(int id);

        Task<Interaction> GetAsync(int id);

        Task<Boolean> Test();
        
    }
}
