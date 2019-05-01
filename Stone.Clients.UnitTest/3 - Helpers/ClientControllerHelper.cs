using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Core;
using Stone.Clients.Messages;
using Stone.Clients.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using System.Threading.Tasks;

namespace Stone.Clients.UnitTest.Helpers
{
    internal class ClientControllerHelper
    {
        private static ClientController Controller { get; set; }

        internal static ClientController GetMock()
        {
            Controller = Substitute.For<ClientController>(ClientApplicationHelper.GetMock());
            Controller.PostAsync(Arg.Any<ClientMessage>()).Returns(PostAsyncReturn);

            return Controller;
        }

        private static Task<IActionResult> PostAsyncReturn(CallInfo info)
        {
            IApplicationResult<bool> result = new ApplicationResult<bool>();
            ClientMessage message = info.Arg<ClientMessage>();

            result.Data = Controller.TryValidateModel(message);

            return Task.FromResult<IActionResult>(result);
        }

    }
}
