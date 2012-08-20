using System;

namespace andrena.Usus.net.Core.Verification
{
    public abstract class Expectation : Attribute
    {
        public abstract string What { get; }

        public object Message
        {
            get { return String.Format("\"{0}\" [{1}]", What, ToString()); }
        }
    }
}
