using NSubstitute;
using NSubstitute.Core;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Clients.UnitTest.DataProviders
{
    internal static class ClientRepositoryHelper
    {
        private static List<Client> Clients { get; set; } = new List<Client>();

        internal static IClientRepository GetMock()
        {
            IClientRepository repository = Substitute.For<IClientRepository>();

            repository.GetAsync(Arg.Any<string>()).Returns(GetAsyncReturn);
            repository.GetAllAsync().Returns(GetAllAsyncReturn);
            repository.RegisterAsync(Arg.Any<Client>()).Returns(RegisterAsyncReturn);

            return repository;
        }

        private static Client GetAsyncReturn(CallInfo info)
        {
            return Clients.FirstOrDefault(it => it.Cpf == info.Arg<string>());
        }

        private static List<Client> GetAllAsyncReturn(CallInfo info)
        {
            return Clients;
        }

        private static Task RegisterAsyncReturn(CallInfo info)
        {
            Clients.Add(info.Arg<Client>());
            return Task.CompletedTask;
        }
    }
}
