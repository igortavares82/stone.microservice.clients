using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Domain.Concretes.EntityService
{
    public class ClientEntityService : IClientEntityService
    {
        private IClientRepository ClientRepository { get; }

        public ClientEntityService(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        public Task<Client> GetAsync(string cpf)
        {
            return ClientRepository.GetAsync(cpf);
        }

        public Task<List<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterAsync(Client model)
        {
            string result = "Client has been registered successfully";

            Client registeredClient = await ClientRepository.GetAsync(model.Cpf);

            if (registeredClient == null)
                await ClientRepository.RegisterAsync(model);
            else
                result = "Client already registered";

            return result;
        }
    }
}
