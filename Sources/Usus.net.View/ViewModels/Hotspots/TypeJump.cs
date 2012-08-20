using System.Collections.Generic;
using System.Linq;
using System.Windows;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class TypeJump
    {
        private readonly MetricsReport metrics;
        private readonly TypeMetricsReport type;
        private readonly IJumpToSource jumper;

        public static void To(MetricsReport metrics, TypeMetricsReport type, IJumpToSource jumper)
        {
            new TypeJump(metrics, type, jumper).Jump();
        }

        public TypeJump(MetricsReport metrics, TypeMetricsReport type, IJumpToSource jumper)
        {
            this.metrics = metrics;
            this.type = type;
            this.jumper = jumper;
        }

        public void Jump()
        {
            var firstMethod = FirstMethodInType();
            if (HasJumpableLocation(firstMethod))
                JumpToMethod(jumper, firstMethod);
            else
                MessageBox.Show(type.FullName + " has no jumpable lines.");
        }

        private void JumpToMethod(IJumpToSource jumper, MethodMetricsReport firstMethod)
        {
            jumper.JumpToFileLocation(
                firstMethod.SourceLocation.Filename,
                firstMethod.SourceLocation.Line, true);
        }

        private bool HasJumpableLocation(MethodMetricsReport firstMethod)
        {
            return firstMethod != null && firstMethod.SourceLocation.IsAvailable;
        }

        private MethodMetricsReport FirstMethodInType()
        {
            return AllJumpableMethods().WithMin(m => m.SourceLocation.Line);
        }

        private IEnumerable<MethodMetricsReport> AllJumpableMethods()
        {
            return from method in metrics.MethodsOfType(type)
                   where method.SourceLocation.IsAvailable
                   select method;
        }
    }
}