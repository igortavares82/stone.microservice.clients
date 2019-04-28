using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Models.Entities;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using Stone.Framework.Result.Enums;
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

        public async Task<IDomainResult<Client>> GetAsync(string cpf)
        {
            IDomainResult<Client> result = new DomainResult<Client>()
            {
                Data = await ClientRepository.GetAsync(cpf)
            };

            return result;
        }

        public async Task<IDomainResult<List<Client>>> GetAllAsync()
        {
            IDomainResult<List<Client>> result = new DomainResult<List<Client>>()
            {
                Data = await ClientRepository.GetAllAsync()
            };

            return result;
        }

        public async Task<IDomainResult<bool>> RegisterAsync(Client model)
        {
            IDomainResult<bool> result = new DomainResult<bool>();
            Client registeredClient = await ClientRepository.GetAsync(model.Cpf);

            if (registeredClient == null)
            {
                await ClientRepository.RegisterAsync(model);
                result.Messages.Add("Client has been registered successfully");
            }
            else
            {
                result.ResultType = DomainResultType.DomainError;
                result.Messages.Add("Client already registered");
            }

            return result;
        }
    }
}
