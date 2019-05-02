using Stone.Clients.Messages;
using Stone.Clients.UnitTest.DataProviders;
using Stone.Clients.UnitTest.Helpers;
using Stone.Clients.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Clients.UnitTest.WebApi
{
    public class ClientControllerTest
    {
        [Theory]
        [MemberData(nameof(ClientMessageDataProvider.GetValidClientMessage), MemberType = typeof(ClientMessageDataProvider))]
        public async Task RegisterClient_ValidateAllData_ReturnsTrue(ClientMessage clientMessage)
        {
            // Arrange
            ClientController controller = ClientControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(clientMessage) as IApplicationResult<bool>;

            // Assert
            Assert.True(result.Data);
        }

        [Theory]
        [MemberData(nameof(ClientMessageDataProvider.GetInvalidCpfClientMessage), MemberType = typeof(ClientMessageDataProvider))]
        public async Task RegisterClient_ValidateCpf_ReturnsFalse(ClientMessage clientMessage)
        {
            // Arrange
            ClientController controller = ClientControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(clientMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("Cpf", result.Messages.First());
        }

        [Theory]
        [MemberData(nameof(ClientMessageDataProvider.GetInvalidNameClientMessage), MemberType = typeof(ClientMessageDataProvider))]
        public async Task RegisterClient_ValidateName_ReturnsFalse(ClientMessage clientMessage)
        {
            // Arrange
            ClientController controller = ClientControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(clientMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("Name", result.Messages.First());
        }

        [Theory]
        [MemberData(nameof(ClientMessageDataProvider.GetInvalidStateClientMessage), MemberType = typeof(ClientMessageDataProvider))]
        public async Task RegisterClient_ValidateState_ReturnsFalse(ClientMessage clientMessage)
        {
            // Arrange
            ClientController controller = ClientControllerHelper.GetMock();

            // Act
            IApplicationResult<bool> result = await controller.PostAsync(clientMessage) as IApplicationResult<bool>;

            // Assert
            Assert.False(result.Data);
            Assert.True(result.Messages.Count == 1);
            Assert.Contains("State", result.Messages.First());
        }
    }
}
