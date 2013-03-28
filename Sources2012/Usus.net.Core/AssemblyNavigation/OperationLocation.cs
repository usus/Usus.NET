using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal class OperationLocation
    {
        public IOperation Operation { get; set; }
        public OperationCode OperationCode
        {
            get { return Operation.OperationCode; }
        }

        public IPrimarySourceLocation Location { get; set; }
        public bool IsValidLocation
        {
            get { return Location.Length != 0; }
        }
    }
}
