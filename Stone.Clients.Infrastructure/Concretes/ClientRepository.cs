using Microsoft.Extensions.Options;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Models.Entities;
using Stone.Framework.Data.Concretes;
using Stone.Framework.Data.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Clients.Infrastructure.Concretes
{
    public class ClientRepository : FirebaseRepository<Client>, IClientRepository
    {
        public ClientRepository(IOptions<FirebaseClientOptions> clientOptions) : base(clientOptions) { }

        public async Task RegisterAsync(Client model)
        {
            await base.InsertAsync(model);
        }

        public async Task<Client> GetAsync(string cpf)
        {
            IEnumerable<Client> clients = await base.GetAsync(it => it.Cpf == cpf);
            return clients.FirstOrDefault();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            IEnumerable<Client> clients = await base.GetAllAsync();
            return clients.ToList();
        }
    }
}
