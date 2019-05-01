using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Models.Entities;
using Stone.Clients.UnitTest.DataProviders;
using Stone.Framework.Result.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Clients.UnitTest.Domain
{
    public class ClientServiceTaskTest
    {
        [Theory]
        [ClassData(typeof(ClientDataProvider))]
        public async Task RegisterClient_RegisterNewClient_ReturnsTrue(Client client)
        {
            // Arrange
            IClientEntityService service = ClientEntityServiceHelper.GetMock();

            // Act
            IDomainResult<bool> result = await service.RegisterAsync(client);

            // Assert
            Assert.True(result.Data);
        }

        [Theory]
        [ClassData(typeof(ClientDataProvider))]
        public async Task RegisterClient_RegisterSameClient_ReturnsFalse(Client client)
        {
            // Arrange
            IClientEntityService service = ClientEntityServiceHelper.GetMock();
            await service.RegisterAsync(client);

            // Act
            IDomainResult<bool> result = await service.RegisterAsync(client);

            // Assert
            Assert.False(result.Data);
        }
    }
}
