using AutoMapper;
using act.API.Common.Settings;
using act.Services.Contracts;
using act.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace act.Services
{
    public class InteractionService : IInteractionService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public InteractionService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<Interaction> CreateAsync(Interaction interaction)
        {
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
                Firstname = "Firstname",
                Lastname = "Lastname",
                Relation = new Relation
                {
                    City = "City",
                    Country = "Country",
                    Street = "Street",
                    ZipCode = "ZipCode"
                }
            };
        }

        public async Task<Boolean> Test()
        {
            return true;
        }
    }
}
