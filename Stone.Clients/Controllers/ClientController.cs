﻿using System;
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

        [HttpGet, Produces("application/json", Type = typeof(ClientMessage))]
        public async Task<List<ClientMessage>> Get()
        {
            return await ClientApplication.GetAllAsync();
        }

        [HttpGet("{cpf}"), Produces("application/json", Type = typeof(ClientMessage))]
        public async Task<ClientMessage> Get([FromRoute] ClientSearchMessage message)
        {
            return await ClientApplication.GetAsync(message);
        }

        [HttpPost, Produces("application/json", Type = typeof(string))]
        public async Task<string> Post([FromBody] ClientMessage message)
        {
            return await ClientApplication.RegisterAsync(message);
        }
    }
}
