using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Graphs
{
    public class StronglyConntectedComponents<T>
    {
        IDictionary<int, List<T>> idToVertices;
        IDictionary<T, int> vertexToId;

        public StronglyConntectedComponents(IDictionary<T, int> vertexToId, IDictionary<int, List<T>> idToVertices)
        {
            this.vertexToId = vertexToId;
            this.idToVertices = idToVertices;
        }

        public StronglyConntectedComponent<T> OfVertex(T vertex)
        {
            return new StronglyConntectedComponent<T>(idToVertices[vertexToId[vertex]]);
        }

        public int Count(Func<StronglyConntectedComponent<T>, bool> condition)
        {
            return idToVertices.Select(vs => new StronglyConntectedComponent<T>(vs.Value)).Count(condition);
        }
    }
}
