using Stone.Clients.Application.Abstractions;
using Stone.Clients.Application.Mappers;
using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Messages;
using Stone.Clients.Models.Entities;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Mappers;
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

        public async Task<IApplicationResult<ClientMessage>> GetAsync(ClientSearchMessage message)
        {
            IDomainResult<Client> domainResult = await ClientEntityService.GetAsync(message.Cpf);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => ClientMapper.MapTo(domain));
        }

        public async Task<IApplicationResult<List<ClientMessage>>> GetAllAsync()
        {
            IDomainResult<List<Client>> domainResult = await ClientEntityService.GetAllAsync();
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => ClientMapper.MapTo(domain));
        }

        public async Task<IApplicationResult<bool>> RegisterAsync(ClientMessage message)
        {
            IDomainResult<bool> domainResult = await ClientEntityService.RegisterAsync(ClientMapper.MapTo(message));
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }
    }
}
