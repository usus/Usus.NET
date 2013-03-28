using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public class StronglyConntectedComponent<T>
    {
        List<T> vertexList;
        public IEnumerable<T> Vertices { get { return vertexList; } }
        public int VertexCount { get { return vertexList.Count; } }

        internal StronglyConntectedComponent(List<T> vertices)
        {
            vertexList = vertices;
        }
    }
}
