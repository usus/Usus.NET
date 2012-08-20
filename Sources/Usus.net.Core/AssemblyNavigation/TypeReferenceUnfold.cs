using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.Immutable;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeReferenceUnfold
    {
        public static IEnumerable<ITypeReference> GetAllRealTypeReferences(this ITypeReference typeReference)
        {
            if (typeReference is IGenericTypeInstanceReference)
                return AnalyzeGenericTypeReference(typeReference as IGenericTypeInstanceReference);
            else
                return AnalyzeNonGenericTypeReference(typeReference);
        }

        #region non generics
        private static IEnumerable<ITypeReference> AnalyzeNonGenericTypeReference(ITypeReference typeReference)
        {
            if (typeReference is Vector)
                return AnalyzeVectorTypeReference(typeReference);
            else
                return AnalyzeNonVectorTypeReference(typeReference);
        }

        private static IEnumerable<ITypeReference> AnalyzeVectorTypeReference(ITypeReference typeReference)
        {
            return (typeReference as Vector).ElementType.GetAllRealTypeReferences();
        }

        private static IEnumerable<ITypeReference> AnalyzeNonVectorTypeReference(ITypeReference typeReference)
        {
            yield return typeReference;
        } 
        #endregion

        #region generics
        private static IEnumerable<ITypeReference> AnalyzeGenericTypeReference(IGenericTypeInstanceReference typeReference)
        {
            return GetGenericType(typeReference)
                .Union(GetGenericTypeArguments(typeReference));
        }

        private static IEnumerable<ITypeReference> GetGenericType(IGenericTypeInstanceReference typeReference)
        {
            yield return typeReference.GenericType;
        }

        private static IEnumerable<ITypeReference> GetGenericTypeArguments(IGenericTypeInstanceReference typeReference)
        {
            return from a in typeReference.GenericArguments
                   from t in a.GetAllRealTypeReferences()
                   select t;
        } 
        #endregion
    }
}
