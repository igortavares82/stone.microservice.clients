using Stone.Clients.Messages;
using Stone.Framework.Utils.Cpf;
using System;
using System.Collections.Generic;

namespace Stone.Clients.UnitTest.DataProviders
{
    public class ClientMessageDataProvider 
    {
        public static IEnumerable<object[]> GetValidClientMessage()
        {
            yield return new object[]
            {
                new ClientMessage() { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = "XX" }
            };
        }

        public static IEnumerable<object[]> GetInvalidCpfClientMessage()
        {
            yield return new object[]
            {
                new ClientMessage() { Cpf = CpfGenerator.Generate().Remove(10).PadRight(1), Name = Guid.NewGuid().ToString(), State = "XX" }
            };
        }

        public static IEnumerable<object[]> GetInvalidNameClientMessage()
        {
            yield return new object[]
            {
                new ClientMessage() { Cpf = CpfGenerator.Generate(), Name = string.Empty, State = "XX" }
            };
        }

        public static IEnumerable<object[]> GetInvalidStateClientMessage()
        {
            yield return new object[]
            {
                new ClientMessage() { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = string.Empty }
            };
        }
    }
}
