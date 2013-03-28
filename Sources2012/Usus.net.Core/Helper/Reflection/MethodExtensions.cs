using System;
using System.Linq.Expressions;
using System.Reflection;

namespace andrena.Usus.net.Core.Helper.Reflection
{
    public static class MethodExtensions
    {
        public static string GetCalleeName(this MethodCallExpression methodCall)
        {
            return methodCall != null ? methodCall.Method.GetFullName() : null;
        }

        public static string GetFullName(this MethodInfo method)
        {
            return String.Format("{0} {1}.{2}",
                method.FullReturnTypeName(),
                method.FullDeclaringType(),
                method.MethodNameAndParameters());
        }

        private static string FullDeclaringType(this MethodInfo method)
        {
            return Normalize.SubTypeName(method.DeclaringType.FullName);
        }

        private static string FullReturnTypeName(this MethodInfo method)
        {
            if (method.ReturnType.IsGenericType)
                return Normalize.GenericName(method.ReturnParameter.ToString());
            else
                return method.ReturnType.FullName;
        }

        private static string MethodNameAndParameters(this MethodInfo method)
        {
            return Normalize.MethodName(method.JustName());
        }

        private static string JustName(this MethodInfo method)
        {
            return method.ToString().StartingAfterFirst(" ");
        }
    }
}
