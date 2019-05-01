using Stone.Clients.Models.Entities;
using Stone.Framework.Utils.Cpf;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Stone.Clients.UnitTest.DataProviders
{
    internal class ClientDataProvider : IEnumerable<object[]>
    {
        private readonly List<object[]> models = new List<object[]>()
        {
            new object[] 
            {
                new Client { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = "XX" }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => models.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
