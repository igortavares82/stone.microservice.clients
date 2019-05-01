using NSubstitute;
using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Domain.Concretes.EntityService;

namespace Stone.Clients.UnitTest.DataProviders
{
    internal class ClientEntityServiceHelper 
    {
        internal static IClientEntityService GetMock()
        {
            return Substitute.For<ClientEntityService>(ClientRepositoryHelper.GetMock());
        }
    }
}
