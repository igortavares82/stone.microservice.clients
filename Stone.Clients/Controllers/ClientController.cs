using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stone.Clients.Application.Abstractions;
using Stone.Clients.Messages;

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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost, Produces("application/json", Type = typeof(string))]
        public async Task<string> Post([FromBody] ClientMessage message)
        {
            return await ClientApplication.RegisterAsync(message);
        }
    }
}
