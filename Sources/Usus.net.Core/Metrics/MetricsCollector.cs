using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Metrics.Methods;
using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics
{
    internal class MetricsCollector : TypeVisitor
    {
        protected override TypeMetricsReport AnalyzeType(INamedTypeDefinition type, PdbReader pdb, IEnumerable<MethodMetricsReport> methods)
        {
            return new TypeMetricsReport
            {
                Name = type.Name(),
                FullName = type.FullName(),
                SourceLocation = SourceCodeLocating.OfType(type, pdb),
                Namespaces = type.Namespaces(),
                CompilerGenerated = type.IsGeneratedCode(),
                NumberOfFields = NumberOfFields.Of(type),
                NumberOfNonStaticPublicFields = NumberOfFields.NotStaticAndPublic(type),
                NumberOfMethods = NumberOfMethods.Of(type),
                DirectDependencies = DirectDependencies.Of(type, methods)
            };
        }

        protected override MethodMetricsReport AnalyzeMethod(IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            return new MethodMetricsReport
            {
                Name = method.Name(),
                Signature = method.Signature(),
                CompilerGenerated = method.IsGeneratedCode(),
                OnlyDeclaration = method.IsOnlyDeclaration(),
                DefaultConstructor = method.IsDefaultCtor(),
                SourceLocation = SourceCodeLocating.OfMethod(method, pdb),
                CyclomaticComplexity = CyclomaticComplexityOfAst.Of(method, pdb, host),
                NumberOfStatements = NumberOfStatements.Of(method, pdb, host),
                NumberOfRealLines = NumberOfRealLines.Of(method, pdb),
                NumberOfLogicalLines = NumberOfLogicalLines.Of(method, pdb),
                TypeDependencies = TypeDependencies.Of(method)
            };
        }
    }
}