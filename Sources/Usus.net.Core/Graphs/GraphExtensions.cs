using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
	public static class GraphExtensions
	{
		public static MutableGraph<V> ToGraph<V>(this IDictionary<V, IEnumerable<V>> graphDict)
			where V : class
		{
			return new MutableGraph<V>(graphDict);
		}
	}
}
