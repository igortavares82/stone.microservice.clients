using Stone.Clients.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Domain.Abstractions.EntityService
{
    public interface IClientEntityService
    {
        Task<string> RegisterAsync(Client model);
        Task<Client> GetAsync(string cpf);
        Task<List<Client>> GetAllAsync();
    }
}
