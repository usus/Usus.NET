using System.IO;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal abstract class AssemblyVisitor
    {
        public MetricsReport Report { get; private set; }

        public void Analyze(string assemblyPath)
        {
            Report = new MetricsReport();
            using (var host = new PeReader.DefaultHost())
                TryToAnalyzeInHost(assemblyPath, host);
        }

        private void TryToAnalyzeInHost(string toAnalyse, IMetadataHost host)
        {
            var assembly = host.LoadUnitFrom(toAnalyse) as IAssembly;
            if (assembly != null) AnalyzeInHost(toAnalyse, host, assembly);
        }

        private void AnalyzeInHost(string toAnalyse, IMetadataHost host, IAssembly assembly)
        {
            string pdbPath = GetProgramDatabasePath(toAnalyse);
            AnalyzeAssemblyInHost(host, assembly, pdbPath);
        }

        private string GetProgramDatabasePath(string toAnalyse)
        {
            string pdbFile = Path.ChangeExtension(toAnalyse, "pdb");
            return File.Exists(pdbFile) ? pdbFile : null;
        }

        private void AnalyzeAssemblyInHost(IMetadataHost host, IAssembly assembly, string pdbPath)
        {
            if (pdbPath != null)
                AnalyzeAssemblyInHostWithProgramDatabase(assembly, host, pdbPath);
            else
                AnalyzeTypes(assembly, null, host, Report);
        }

        private void AnalyzeAssemblyInHostWithProgramDatabase(IAssembly assembly, IMetadataHost host, string pdbPath)
        {
            using (var pdb = GetProgramDatabase(host, pdbPath))
                AnalyzeTypes(assembly, pdb, host, Report);
        }

        private PdbReader GetProgramDatabase(IMetadataHost host, string pdbPath)
        {
            return new PdbReader(File.OpenRead(pdbPath), host);
        }

        protected abstract void AnalyzeTypes(IAssembly assembly, PdbReader pdb, IMetadataHost host, MetricsReport report);
    }
}
