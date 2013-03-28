using System.IO;
using System.Linq;
using System.Windows;
using andrena.Usus.net.View.Hub;
using Microsoft.Win32;

namespace andrena.Usus.net.Shell
{
    public class ShellViewModel
    {
        public ViewHub Hub { get; private set; }

        public ShellViewModel()
        {
            Hub = ViewHub.Instance;
        }

        public void AnalyzeClicked(Window owner)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog(owner) ?? false)
                StartAnalysis(openFileDialog.FileNames);
        }

        private void StartAnalysis(params string[] files)
        {
            var validFiles = files.Where(file => IsLibraryOrExecutable(file));
            if (validFiles.Any())
                ViewHub.Instance.TryStartAnalysis(files);
            else
                MessageBox.Show("Usus.net Shell only supports analysis of DLLs and EXEs.");
        }

        private bool IsLibraryOrExecutable(string file)
        {
            string extension = new FileInfo(file).Extension.ToLower();
            return extension == ".dll" || extension == ".exe";
        }
    }
}
