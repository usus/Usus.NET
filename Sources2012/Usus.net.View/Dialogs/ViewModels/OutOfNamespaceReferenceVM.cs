using andrena.Usus.net.Core.Helper;
using System.Collections.Generic;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
	public class OutOfNamespaceReferenceVM
	{
		public string Source { get; private set; }
		public string Target { get; private set; }
		public IEnumerable<string> ResponsibleMethods { get; private set; }

		public OutOfNamespaceReferenceVM(OutOfNamespaceReference reference)
		{
			Source = reference.Source.FullName;
			Target = reference.Target.FullName;
			ResponsibleMethods = reference.ReferencingMethods().ToList(m => m.Name);
		}
	}
}
