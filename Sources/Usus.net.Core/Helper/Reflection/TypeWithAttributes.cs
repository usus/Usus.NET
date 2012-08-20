using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Helper.Reflection
{
    public class TypeWithAttributes<T> where T : Attribute
    {
        public IEnumerable<T> Attributes { get; set; }
        public Type Type { get; set; }
    }
}
