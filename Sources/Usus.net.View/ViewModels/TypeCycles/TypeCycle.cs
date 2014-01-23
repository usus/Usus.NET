using System.Collections.Generic;

namespace andrena.Usus.net.View.ViewModels.TypeCycles
{
	public class TypeCycle
	{
		public string DisplayName { get; set; }
		public IEnumerable<Type> TypesInCycle { get; set; }

		public TypeCycle()
		{ }
	}
}
