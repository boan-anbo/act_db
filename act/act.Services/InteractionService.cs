using AutoMapper;
using act.API.Common.Settings;
using act.Services.Contracts;
using act.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using act.Repositories.Db;

namespace act.Services
{
    public class InteractionService : IInteractionService
    {
        private AppSettings _settings;

        private ActDbContext _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// Main logic for interaction
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="mapper"></param>
        /// <param name="db"></param>
        public InteractionService(
            IOptions<AppSettings> settings, 
            IMapper mapper,
            ActDbContext db
            )
        {
            _settings = settings?.Value;
            _mapper = mapper;
            this._db = db;
        }

        public async Task<Interaction> CreateAsync(Interaction interaction)
        {
            return interaction;
        }

        public async Task<Interaction> CreateInteraction(string description)
        {
            // create first interaction with description 
            var interaction =   new Interaction
            {
                Description = description,
            };
            await _db.AddAsync(interaction);
            await _db.SaveChangesAsync();
            return interaction;

        }


        public async Task<bool> UpdateAsync(Interaction interaction)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Interaction> GetAsync(int id)
        {
            return new Interaction
            {
                Id = id,
                Description = "Firstname",
                Notes = "Lastname",
                Relation = new Relation
                {
                    Type = "City",
                    Description = "Street",
                }
            };
        }

        public async Task<Boolean> Test()
        {
            return true;
        }
    }
}
