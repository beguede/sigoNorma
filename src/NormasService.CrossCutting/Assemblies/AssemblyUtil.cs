using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NormasService.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("NormasService.Api"),
                Assembly.Load("NormasService.Application"),
                Assembly.Load("NormasService.Domain"),
                Assembly.Load("NormasService.Domain.Core"),
                Assembly.Load("NormasService.Infrastructure"),
                Assembly.Load("NormasService.CrossCutting")
            };
        }
    }
}
