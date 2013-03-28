using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal abstract class TypeVisitor : AssemblyVisitor
    {
        protected override void AnalyzeTypes(IAssembly assembly, PdbReader pdb, IMetadataHost host, MetricsReport report)
        {
            foreach (var typeMetrics in AnalyzeTypes(assembly, pdb, host))
                report.AddTypeReport(typeMetrics);
        }

        private IEnumerable<TypeMetricsWithMethodMetrics> AnalyzeTypes(IAssembly assembly, PdbReader pdb, IMetadataHost host)
        {
            return from type in assembly.GetAllTypes()
                   where type.Name.ToString() != "<Module>"
                   select TypeAndMethods(pdb, host, type);
        }

        private TypeMetricsWithMethodMetrics TypeAndMethods(PdbReader pdb, IMetadataHost host, INamedTypeDefinition type)
        {
            var typeAndMethods = new TypeMetricsWithMethodMetrics();
            typeAndMethods.AddMethodReports(AnalyzeMethods(type, pdb, host));
            typeAndMethods.Itself = AnalyzeType(type, pdb, typeAndMethods.Methods);
            return typeAndMethods;
        }

        private IEnumerable<MethodMetricsReport> AnalyzeMethods(INamedTypeDefinition type, PdbReader pdb, IMetadataHost host)
        {
            return from method in type.Methods
                   select AnalyzeMethod(method, pdb, host);
        }

        protected abstract TypeMetricsReport AnalyzeType(INamedTypeDefinition type, PdbReader pdb, IEnumerable<MethodMetricsReport> methods);
        protected abstract MethodMetricsReport AnalyzeMethod(IMethodDefinition method, PdbReader pdb, IMetadataHost host);
    }
}
