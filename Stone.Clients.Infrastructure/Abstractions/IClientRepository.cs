using Stone.Clients.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Infrastructure.Abstractions
{
    public interface IClientRepository
    {
        Task<Client> Get(string cpf);
    }
}
