using Microsoft.AspNetCore.Mvc;
using Stone.Clients.Application.Abstractions;
using Stone.Clients.Messages;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private IClientApplication ClientApplication { get; }

        public ClientController(IClientApplication clientApplication)
        {
            ClientApplication = clientApplication;
        }

        [HttpGet("wellcome"), Produces("text/plain", Type = typeof(string))]
        public string GetWellcome() => "Wellcome to client service!";

        [HttpGet("{cpf}"), Produces("application/json", Type = typeof(IApplicationResult<ClientMessage>))]
        public virtual async Task<IActionResult> GetAsync([FromRoute] ClientSearchMessage message)
        {
            return await ClientApplication.GetAsync(message);
        }

        [HttpGet, Produces("application/json", Type = typeof(IApplicationResult<List<ClientMessage>>))]
        public virtual async Task<IActionResult> GetAsync()
        {
            return await ClientApplication.GetAllAsync();
        }

        [HttpPost, Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public virtual async Task<IActionResult> PostAsync([FromBody] ClientMessage message)
        {
            return await ClientApplication.RegisterAsync(message);
        }
    }
}
