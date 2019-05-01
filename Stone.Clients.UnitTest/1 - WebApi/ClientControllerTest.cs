using Stone.Clients.Messages;
using Stone.Clients.UnitTest.DataProviders;
using Stone.Clients.UnitTest.Helpers;
using Stone.Clients.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Clients.UnitTest.WebApi
{
    public class ClientControllerTest
    {
        [Theory]
        [MemberData(nameof(ClientMessageDataProvider.GetValidClientMessage), MemberType = typeof(ClientMessageDataProvider))]
        public async Task RegisterClient_ValidateCpf_ReturnsTrue(ClientMessage clientMessage)
        {
            // Arrange
            ClientController controller = ClientControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(clientMessage) as IApplicationResult<bool>;

            // Assert
            Assert.True(result.Data);
        }
    }
}
