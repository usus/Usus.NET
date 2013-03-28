using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public interface IGraph<V> where V : class
    {
        IEnumerable<V> Vertices { get; }
        IEnumerable<Tuple<V, V>> Edges { get; }
    }
}
