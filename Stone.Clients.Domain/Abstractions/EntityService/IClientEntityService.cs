using Stone.Clients.Models.Entities;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Domain.Abstractions.EntityService
{
    public interface IClientEntityService
    {
        Task<IDomainResult<bool>> RegisterAsync(Client model);
        Task<IDomainResult<Client>> GetAsync(string cpf);
        Task<IDomainResult<List<Client>>> GetAllAsync();
    }
}
