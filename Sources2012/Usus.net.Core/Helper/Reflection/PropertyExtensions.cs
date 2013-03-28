using System;
using System.Linq.Expressions;
using System.Reflection;

namespace andrena.Usus.net.Core.Helper.Reflection
{
    public static class PropertyExtensions
    {
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T>> expression)
        {
            return (expression.Body as MemberExpression).Member as PropertyInfo;
        }

        public static string GetFullGetterName(this PropertyInfo property)
        {
            return property.WithReturnTypeDeclaringTypeAndName("{0} {1}.{2}.get()");
        }

        public static string GetFullSetterName(this PropertyInfo property)
        {
            return property.WithReturnTypeDeclaringTypeAndName("System.Void {1}.{2}.set({0})");
        }

        public static string WithReturnTypeDeclaringTypeAndName(this PropertyInfo property, string format)
        {
            return String.Format(format,
                property.PropertyType.FullName,
                property.DeclaringType.FullName.Replace("+", "."),
                property.Name);
        }
    }
}