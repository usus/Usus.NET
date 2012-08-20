using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class CyclomaticComplexityOfIl
    {
        public static int Of(IMethodDefinition method)
        {
            int num = 1;
            num += method.Body.OperationExceptionInformation.Count(e => e.HandlerKind == HandlerKind.Catch);
            
            foreach (var operation in method.Body.Operations)
            {
                switch (operation.OperationCode)
                {
                    case OperationCode.Brfalse_S:
                    case OperationCode.Brtrue_S:
                    case OperationCode.Beq_S:
                    case OperationCode.Bge_S:
                    case OperationCode.Bgt_S:
                    case OperationCode.Ble_S:
                    case OperationCode.Blt_S:
                    case OperationCode.Bne_Un_S:
                    case OperationCode.Bge_Un_S:
                    case OperationCode.Bgt_Un_S:
                    case OperationCode.Ble_Un_S:
                    case OperationCode.Blt_Un_S:
                    case OperationCode.Brfalse:
                    case OperationCode.Brtrue:
                    case OperationCode.Beq:
                    case OperationCode.Bge:
                    case OperationCode.Bgt:
                    case OperationCode.Ble:
                    case OperationCode.Blt:
                    case OperationCode.Bne_Un:
                    case OperationCode.Bge_Un:
                    case OperationCode.Bgt_Un:
                    case OperationCode.Ble_Un:
                    case OperationCode.Blt_Un:
                    case (OperationCode)0xfefc:
                    case (OperationCode)0xfefe:
                        num++;
                        break;

                    case OperationCode.Switch:
                        {
                            IEnumerable<int> enumerable = (IEnumerable<int>)operation.Value;
                            HashSet<int> set = new HashSet<int>();
                            foreach (int num2 in enumerable)
                            {
                                set.Add(num2);
                            }
                            num += set.Count;
                            break;
                        }
                }
            }
            return num;
        }
    }
}
