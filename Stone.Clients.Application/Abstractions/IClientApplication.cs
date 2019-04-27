﻿using Stone.Clients.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Clients.Application.Abstractions
{
    public interface IClientApplication
    {
        Task<string> RegisterAsync(ClientMessage message);
        Task<ClientMessage> GetAsync(string cpf);
        Task<List<ClientMessage>> GetAllAsync();
    }
}
