using Stone.Clients.Messages;
using Stone.Clients.Models.Entities;
using Stone.Framework.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Clients.Application.Mappers
{
    public class ClientMapper
    {
        public static Client MapTo(ClientMessage message)
        {
            return new Client(message.Name, message.State, message.Cpf.RemoveCpfMask());
        }

        public static ClientMessage MapTo(Client model)
        {
            if (model == null)
                return new ClientMessage();

            return new ClientMessage() { Name = model.Name, State = model.State, Cpf = model.Cpf };
        }

        public static List<ClientMessage> MapTo(List<Client> models)
        {
            if (models == null)
                return new List<ClientMessage>();

            return models.Select(MapTo).ToList();
        }
    }
}
