
namespace andrena.Usus.net.ExtensionHelper
{
    public static class ProjectExtesions
    {
        public static bool HasProperty(this EnvDTE.Project project, string propertyName)
        {
            return !string.IsNullOrEmpty(project.GetPropertyString(propertyName));
        }

        public static string GetPropertyString(this EnvDTE.Project project, string propertyName)
        {
            if (project.Properties != null)
            {
                foreach (EnvDTE.Property item in project.Properties)
                {
                    if (item != null && item.Name == propertyName)
                        return item.Value.ToString();
                }
            }
            return null;
        }
    }
}
