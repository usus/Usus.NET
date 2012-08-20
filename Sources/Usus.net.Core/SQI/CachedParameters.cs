using System;

namespace andrena.Usus.net.Core.SQI
{
    internal class CachedParameters : IParameterProvider
    {
        public CachedParameters(IParameterProvider parameters)
        {
            TestCoverageCached = new Lazy<double>(() => parameters.TestCoverage);
            NamespaceCyclesCached = new Lazy<int>(() => parameters.NamespaceCycles);
            ComplicatedMethodsCached = new Lazy<int>(() => parameters.ComplicatedMethods);
            AverageComponentDependencyCached = new Lazy<double>(() => parameters.AverageComponentDependency);
            BigClassesCached = new Lazy<int>(() => parameters.BigClasses);
            BigMethodsCached = new Lazy<int>(() => parameters.BigMethods);
            CompilerWarningsCached = new Lazy<int>(() => parameters.CompilerWarnings);
            NamespacesCached = new Lazy<int>(() => parameters.Namespaces);
            ClassesCached = new Lazy<int>(() => parameters.Classes);
            MethodsCached = new Lazy<int>(() => parameters.Methods);
            RlocCached = new Lazy<int>(() => parameters.Rloc);
        }

        public Lazy<double> TestCoverageCached { get; private set; }
        public Lazy<int> NamespaceCyclesCached { get; private set; }
        public Lazy<int> ComplicatedMethodsCached { get; private set; }
        public Lazy<double> AverageComponentDependencyCached { get; private set; }
        public Lazy<int> BigClassesCached { get; private set; }
        public Lazy<int> BigMethodsCached { get; private set; }
        public Lazy<int> CompilerWarningsCached { get; private set; }
        public Lazy<int> NamespacesCached { get; private set; }
        public Lazy<int> ClassesCached { get; private set; }
        public Lazy<int> MethodsCached { get; private set; }
        public Lazy<int> RlocCached { get; private set; }

        public double TestCoverage { get { return TestCoverageCached.Value; } }
        public int NamespaceCycles { get { return NamespaceCyclesCached.Value; } }
        public int ComplicatedMethods { get { return ComplicatedMethodsCached.Value; } }
        public double AverageComponentDependency { get { return AverageComponentDependencyCached.Value; } }
        public int BigClasses { get { return BigClassesCached.Value; } }
        public int BigMethods { get { return BigMethodsCached.Value; } }
        public int CompilerWarnings { get { return CompilerWarningsCached.Value; } }
        public int Namespaces { get { return NamespacesCached.Value; } }
        public int Classes { get { return ClassesCached.Value; } }
        public int Methods { get { return MethodsCached.Value; } }
        public int Rloc { get { return RlocCached.Value; } }
    }
}
