using NSubstitute;
using Stone.Clients.Application.Abstractions;
using Stone.Clients.Application.Concretes;
using Stone.Clients.UnitTest.DataProviders;

namespace Stone.Clients.UnitTest.Helpers
{
    internal class ClientApplicationHelper
    {
        internal static IClientApplication GetMock()
        {
            return Substitute.For<ClientApplication>(ClientEntityServiceHelper.GetMock());
        }
    }
}
