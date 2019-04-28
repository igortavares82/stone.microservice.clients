using Stone.Clients.Messages;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Application.Abstractions
{
    public interface IClientApplication
    {
        Task<IApplicationResult<bool>> RegisterAsync(ClientMessage message);
        Task<IApplicationResult<ClientMessage>> GetAsync(ClientSearchMessage message);
        Task<IApplicationResult<List<ClientMessage>>> GetAllAsync();
    }
}
