using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace andrena.Usus.net.Core.Helper.Reflection
{
    public static class AttributeExtensions
    {
        public static IEnumerable<MethodWithAttributes<T>> GetMethodsWithAssigned<T>(this Assembly asm) where T : Attribute
        {
            return (from t in asm.GetTypes()
                    from m in t.GetMethods(GetMemberBindingFlags())
                    where m.Attributes<T>().Any()
                    select new MethodWithAttributes<T>
                    {
                        Method = m,
                        Attributes = m.Attributes<T>()
                    }).ToList();
        }
        
        public static IEnumerable<TypeWithAttributes<T>> GetTypesWithAssigned<T>(this Assembly asm) where T : Attribute
        {
            return (from t in asm.GetTypes()
                    where t.Attributes<T>().Any()
                    select new TypeWithAttributes<T>
                    {
                        Type = t,
                        Attributes = t.Attributes<T>()
                    }).ToList();
        }

        private static IEnumerable<T> Attributes<T>(this MemberInfo member)
        {
            return member.GetCustomAttributes(typeof(T), false).Cast<T>();
        }

        private static BindingFlags GetMemberBindingFlags()
        {
            return BindingFlags.Instance 
                | BindingFlags.Static 
                | BindingFlags.NonPublic 
                | BindingFlags.Public;
        }
    }
}
