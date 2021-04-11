using NormasService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NormasService.Tests.Entities
{
    public class NormaTest
    {
        [Fact]
        public void Norma_Constructor()
        {
            var norma = new Norma();

            Assert.NotEqual(Guid.Empty, norma.Id);
        }
    }
}
