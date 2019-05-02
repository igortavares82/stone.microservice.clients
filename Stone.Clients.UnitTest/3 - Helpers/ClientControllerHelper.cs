using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Core;
using Stone.Clients.Messages;
using Stone.Clients.WebApi.Controllers;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using System.Threading.Tasks;
using Stone.Framework.Utils.ModelValidator;
using System;
using System.Collections.Generic;

namespace Stone.Clients.UnitTest.Helpers
{
    internal class ClientControllerHelper
    {
        internal static ClientController GetMock()
        {
            ClientController controller = Substitute.For<ClientController>(ClientApplicationHelper.GetMock());
            
            controller.PostAsync(Arg.Any<ClientMessage>()).Returns(PostAsyncReturn);

            return controller;
        }

        private static async Task<IActionResult> PostAsyncReturn(CallInfo info)
        {
            IApplicationResult<bool> result = new ApplicationResult<bool>();
            Tuple<bool, List<string>> validationResult = Validator.Validate(info.Arg<ClientMessage>());

            result.Data = validationResult.Item1;
            result.Messages.AddRange(validationResult.Item2);

            return result;
        }

    }
}
