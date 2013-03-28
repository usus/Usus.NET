using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class SourceCodeLocating
    {
        public static SourceCodeLocation OfMethod(this IMethodDefinition method, PdbReader pdb)
        {
            return Of(method, pdb);
        }

        public static SourceCodeLocation OfType(this INamedTypeDefinition type, PdbReader pdb)
        {
            return SourceCodeLocation.None;
        }

        private static SourceCodeLocation Of(this IObjectWithLocations locatable, PdbReader pdb)
        {
            IPrimarySourceLocation location = locatable.GetValidLocation(pdb);
            return location != null ? location.ToSourceCodeLocation() : SourceCodeLocation.None;
        }

        private static SourceCodeLocation ToSourceCodeLocation(this IPrimarySourceLocation location)
        {
            return new SourceCodeLocation
            {
                Filename = location.Document.Location,
                Line = location.StartLine
            };
        }

        private static IPrimarySourceLocation GetValidLocation(this IObjectWithLocations locatable, PdbReader pdb)
        {
            return pdb == null ? null : locatable.GetValidLocations(pdb).FirstOrDefault();
        }

        private static IEnumerable<IPrimarySourceLocation> GetValidLocations(this IObjectWithLocations locatable, PdbReader pdb)
        {
            return from l in pdb.GetPrimarySourceLocationsFor(locatable.Locations)
                   where l.Length != 0
                   select l;
        }
    }
}
