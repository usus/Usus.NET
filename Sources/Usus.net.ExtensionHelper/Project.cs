using System;
using System.IO;

namespace andrena.Usus.net.ExtensionHelper
{
    public class Project
    {
        public string Name { get; private set; }
        public string ProjectPath { get; private set; }
        public string ProjectFile { get; private set; }
        public FileInfo OutputAssembly { get; private set; }

        internal static bool IsValid(EnvDTE.Project project)
        {
            try
            {
                return project.Properties != null 
                    && !string.IsNullOrEmpty(project.FullName) 
                    && project.HasProperty("FullPath");
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal Project(EnvDTE.Project project)
        {
            Name = project.Name;
            ProjectFile = project.FullName;
            ProjectPath = project.GetPropertyString("FullPath");
            var outputPath = project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();
            var outputFileName = project.GetPropertyString("OutputFileName");
            OutputAssembly = new FileInfo(Path.Combine(ProjectPath, outputPath, outputFileName));
        }
    }
}
