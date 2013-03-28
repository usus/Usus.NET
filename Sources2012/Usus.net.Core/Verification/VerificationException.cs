using System;
using System.Reflection;
using andrena.Usus.net.Core.Helper.Reflection;

namespace andrena.Usus.net.Core.Verification
{
    public class VerificationException : Exception
    {
        private const string MESSAGE = "\"{0}\" does not meet expectation {1}";

        public VerificationException(MethodInfo method, MethodExpectation expectation)
            : base(String.Format(MESSAGE, method.GetFullName(), expectation.Message))
        {
        }

        public VerificationException(Type type, TypeExpectation expectation)
            : base(String.Format(MESSAGE, type.GetFullName(), expectation.Message))
        {
        }
    }
}
