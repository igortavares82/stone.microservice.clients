using Stone.Clients.Application.Abstractions;
using Stone.Clients.Application.Mappers;
using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Messages;
using Stone.Clients.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Application.Concretes
{
    public class ClientApplication : IClientApplication
    {
        private IClientEntityService ClientEntityService { get; }

        public ClientApplication(IClientEntityService clientEntityService)
        {
            ClientEntityService = clientEntityService;
        }

        public async Task<ClientMessage> GetAsync(ClientSearchMessage message)
        {
            Client model = await ClientEntityService.GetAsync(message.Cpf);
            return ClientMapper.MapTo(model);
        }

        public async Task<List<ClientMessage>> GetAllAsync()
        {
            List<Client> clients = await ClientEntityService.GetAllAsync();
            return ClientMapper.MapTo(clients);
        }

        public async Task<string> RegisterAsync(ClientMessage message)
        {
            Client model = ClientMapper.MapTo(message);
            return await ClientEntityService.RegisterAsync(model);
        }
    }
}
