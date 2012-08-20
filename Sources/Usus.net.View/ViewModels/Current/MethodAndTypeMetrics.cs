using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Current
{
    public class MethodAndTypeMetrics
    {
        MethodMetricsReport method;
        TypeMetricsReport type;

        internal MethodAndTypeMetrics(TypeMetricsReport type, MethodMetricsReport method)
        {
            this.method = method;
            this.type = type;
        }

        public string MethodName { get { return method.Name; } }

        public IEnumerable<Tuple<string, string>> Info
        {
            get
            {
                yield return Tuple.Create("Name", method.Name);
                yield return Tuple.Create("Length", method.MethodLength.ToString());
                yield return Tuple.Create("Cyclomatic Complexity", method.CyclomaticComplexity.ToString());
                yield return Tuple.Create("(Class) Size", type.ClassSize.ToString());
                yield return Tuple.Create("(Class) Non-static public fields", type.NumberOfNonStaticPublicFields.ToString());
                yield return Tuple.Create("(Class) Direct Dependencies", type.InterestingDirectDependencies.Count().ToString());
                yield return Tuple.Create("(Class) Cumulative Component Dependency", type.CumulativeComponentDependency.ToString());
            }
        }
    }
}
