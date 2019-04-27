using Stone.Clients.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Infrastructure.Abstractions
{
    public interface IClientRepository
    {
        Task RegisterAsync(Client model);
        Task<Client> GetAsync(string cpf);
        Task<List<Client>> GetAllAsync();
    }
}
