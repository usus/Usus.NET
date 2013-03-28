using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfRealLines
    {
        public static int Of(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                if (pdb.IsIterator(method.Body)) return -1;
                var locations = method.LocatedOperations(pdb);
                return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<OperationLocation> locations)
        {
            if (!locations.GetAllValidLines(l => l.EndLine).Any()) return 0;
            var firstLine = locations.GetAllValidLines(l => l.EndLine).Min();
            var lastLine = locations.GetAllValidLines(l => l.EndLine).Max();
            return System.Math.Max(0, lastLine - firstLine - 1);
        }

        private static IEnumerable<int> GetAllValidLines(this IEnumerable<OperationLocation> locations, Func<IPrimarySourceLocation, int> line)
        {
            return from l in locations
                   where l.IsValidLocation
                   select line(l.Location);
        }
    }
}
