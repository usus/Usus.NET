using System.Collections.Generic;

namespace andrena.Usus.net.View.ViewModels.TypeCycles
{
	public class Type
	{
		public string DisplayName { get; set; }
		public IEnumerable<TypeReferenceVM> ReferencedTypes { get; set; }

		public Type()
		{ }
	}
}
