using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using System.Collections.Generic;

namespace andrena.Usus.net.View.Dialogs.NamespaceCycles
{
	public class TypeReferenceVM
	{
		public string Source { get; private set; }
		public string Target { get; private set; }
		public IEnumerable<string> ResponsibleMethods { get; private set; }

		public TypeReferenceVM(TypeReference reference)
		{
			Source = reference.Source.FullName;
			Target = reference.Target.FullName;
			ResponsibleMethods = reference.ReferencingMethods().ToList(m => m.Name);
		}
	}
}
