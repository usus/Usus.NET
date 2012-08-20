using System;
using System.Reflection;
using andrena.Usus.net.Core.Helper.Reflection;

namespace andrena.Usus.net.Core.Verification
{
    public class MetricsNotFoundException : Exception
    {
        private const string MESSAGE = "No metrics found for \"{0}\"";

        public MetricsNotFoundException(MethodInfo method)
            : base(String.Format(MESSAGE, method.GetFullName()))
        {
        }
        
        public MetricsNotFoundException(Type type)
            : base(String.Format(MESSAGE, type.GetFullName()))
        {
        }
    }
}
