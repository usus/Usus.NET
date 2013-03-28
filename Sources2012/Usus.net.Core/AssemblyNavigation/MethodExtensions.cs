using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.ILToCodeModel;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class MethodExtensions
    {
        public static string Signature(this IMethodDefinition method)
        {
            return method.ToString().Replace(", ", ",");
        }

        public static string Name(this IMethodDefinition method)
        {
            return method.Name.ToString();
        }

        public static bool IsOnlyDeclaration(this IMethodDefinition method)
        {
            return method.IsAbstract;
        }

        public static bool HasOperations(this IMethodDefinition method)
        {
            return method.Body.Operations.Any();
        }

        public static bool IsDefaultCtor(this IMethodDefinition method)
        {
            return method.ToString().EndsWith("..ctor()");
        }

        public static IEnumerable<IOperation> Operations(this IMethodDefinition method,
            Func<OperationCode, bool> predicate)
        {
            return from o in method.Body.Operations
                   where predicate(o.OperationCode)
                   select o;
        }

        public static IEnumerable<string> TypesOfOperations(this IMethodDefinition method,
           Func<OperationCode, bool> predicate,
           Func<IOperation, IEnumerable<ITypeReference>> selector)
        {
            return from o in method.Operations(predicate)
                   from t in selector(o)
                   from rt in t.GetAllRealTypeReferences()
                   select rt.ToString();
        }

        public static IEnumerable<OperationLocation> LocatedOperations(this IMethodDefinition method, PdbReader pdb)
        {
            return (from o in method.Body.Operations
                    from l in pdb.GetPrimarySourceLocationsFor(o.Location)
                    select new OperationLocation { Operation = o, Location = l }).ToList();
        }

        public static SourceMethodBody Decompile(this IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            return new SourceMethodBody(method.Body, host, pdb, pdb,
                       DecompilerOptions.Loops |
                       DecompilerOptions.AnonymousDelegates |
                       DecompilerOptions.Iterators);
        }

        public static IEnumerable<IStatement> Statements(this SourceMethodBody methodBody)
        {
            return methodBody.Block.Statements;
        }
    }
}
