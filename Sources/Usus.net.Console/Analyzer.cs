using System;
using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Console
{
    abstract class Analyzer
    {
        public void AnalyzeThisAssembly()
        {
            var metrics = Analyze.Me();
            OutputMetricsReport(metrics);
        }

        public void AnalyzeFile(string assemblyToAnalyze)
        {
            var metrics = Analyze.PortableExecutables(assemblyToAnalyze);
            OutputMetricsReport(metrics);
        }

        private void OutputMetricsReport(MetricsReport metrics)
        {
            foreach (var namespaceMetrics in metrics.Namespaces)
                OutputNamespaceMetricsReport(namespaceMetrics);

            OutputSeperator(2);

            foreach (var type in metrics.Types.Where(t => !t.CompilerGenerated))
                OutputTypeMetricsReport(type);

            OutputSeperator(2);

            foreach (var method in metrics.Methods.Where(m => !m.CompilerGenerated && !m.OnlyDeclaration))
                OutputMethodMetricsReport(method);

            OutputSeperator(3);

            OutputRatings(metrics.Rate());
            OutputHotspots(metrics.Hotspots());
        }

        private void OutputSeperator()
        {
            Output("---------------------------------------------------");
        }

        private void OutputSeperator(int times)
        {
            for (int i = 0; i < times; i++)
                OutputSeperator();
        }

        private void OutputMethodMetricsReport(MethodMetricsReport methodMetrics)
        {
            OutputSeperator();
            Output(String.Format("Name:\t\t{0}", methodMetrics.Name));
            Output(String.Format("Signature:\t{0}", methodMetrics.Signature));
            Output(String.Format("Generated:\t{0}", methodMetrics.CompilerGenerated));
            Output(String.Format("\tCyclomaticComplexity:\t{0}", methodMetrics.CyclomaticComplexity));
            Output(String.Format("\tNumberOfStatements:\t{0}", methodMetrics.NumberOfStatements));
            Output(String.Format("\tNumberOfRealLines:\t{0}", methodMetrics.NumberOfRealLines));
            Output(String.Format("\tNumberOfLogicalLines:\t{0}", methodMetrics.NumberOfLogicalLines));
            Output();
        }

        private void OutputTypeMetricsReport(TypeMetricsReport typeMetrics)
        {
            OutputSeperator();
            Output(String.Format("Name:\t\t{0}", typeMetrics.Name));
            Output(String.Format("Fullname:\t{0}", typeMetrics.FullName));
            Output(String.Format("Generated:\t{0}", typeMetrics.CompilerGenerated));
            Output(String.Format("\tNumberOfNonStaticPublicFields:\t{0}", typeMetrics.NumberOfNonStaticPublicFields));
            Output(String.Format("\tClassSize:\t\t\t{0}", typeMetrics.ClassSize));
            Output(String.Format("\tCumulativeComponentDependency:\t{0}", typeMetrics.CumulativeComponentDependency));
            Output(String.Format("\tInterestingDependencies:\t{0}", string.Join(", ", typeMetrics.InterestingDirectDependencies)));
            Output();
        }

        private void OutputNamespaceMetricsReport(NamespaceMetricsReport namespaceMetrics)
        {
            OutputSeperator();
            Output(String.Format("Name:\t\t{0}", namespaceMetrics.Name));
            Output(String.Format("NumberOfNamespacesInCycle:\t{0}", namespaceMetrics.NumberOfNamespacesInCycle));
            Output();
        }

        private void OutputRatings(RatedMetrics rated)
        {
            Output("Overall Metrics");
            Output(String.Format("\tAverageRatedCyclomaticComplexity:\t\t{0}", rated.AverageRatedCyclomaticComplexity));
            Output(String.Format("\tAverageRatedMethodLength:\t\t\t{0}", rated.AverageRatedMethodLength));
            Output(String.Format("\tAverageRatedClassSize:\t\t\t\t{0}", rated.AverageRatedClassSize));
            Output(String.Format("\tAverageRatedNumberOfNonStaticPublicFields:\t{0}", rated.AverageRatedNumberOfNonStaticPublicFields));
            Output(String.Format("\tAverageComponentDependency:\t\t\t{0}", rated.AverageComponentDependency));
            Output(String.Format("\tNamespacesWithCyclicDependencies:\t\t{0}", rated.NamespacesWithCyclicDependencies));
            Output();
        }

        private void OutputHotspots(MetricsHotspots hotspots)
        {
            Output("Hotspots");
            Output(String.Format("\tCyclomaticComplexity:\t\t\t{0}", string.Join(", ", hotspots.OfCyclomaticComplexity().Select(h => h.Signature))));
            Output(String.Format("\tMethodLength:\t\t\t\t{0}", string.Join(", ", hotspots.OfMethodLength().Select(h => h.Signature))));
            Output(String.Format("\tClassSize:\t\t\t\t{0}", string.Join(", ", hotspots.OfClassSize().Select(h => h.FullName))));
            Output(String.Format("\tNumberOfNonStaticPublicFields:\t\t{0}", string.Join(", ", hotspots.OfNumberOfNonStaticPublicFields().Select(h => h.FullName))));
            Output(String.Format("\tCumulativeComponentDependency ({0}):\t{1}", GetCcdLimit(hotspots), string.Join(", ", hotspots.OfCumulativeComponentDependency().Select(h => h.FullName))));
            Output(String.Format("\tNamespacesWithCyclicDependencies:\t{0}", string.Join(", ", hotspots.OfNamespacesInCycle().Select(h => h.Name))));
            Output();
        }

        private int GetCcdLimit(MetricsHotspots hotspots)
        {
            return RatingFunctions.Limits.CumulativeComponentDependency(hotspots.Metrics.CommonKnowledge);
        }

        protected abstract void Output(string line);
        protected abstract void Output();
    }
}
