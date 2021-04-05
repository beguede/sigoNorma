using NormasService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NormasService.Tests.Mocks
{
    public static class FakeNorma
    {
        public static Norma ObterNormaDefault()
        {
            Norma norma = new Norma
            {
                Codigo = "ISO 9000:2015"
            };

            return norma;
        }
    }
}
