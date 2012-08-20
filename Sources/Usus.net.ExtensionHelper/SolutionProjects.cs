using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;

namespace andrena.Usus.net.ExtensionHelper
{
    /* •———————————————————————————————————————————————————————————————————————————————————————————————————————————————•
       | Based on the ideo of Scott Mackay                                                                                       |
       | http://www.wwwlicious.com/2011/03/envdte-getting-all-projects.html#!/2011/03/envdte-getting-all-projects.html |
       | Posted 29th March 2011                                                                                        |
       •———————————————————————————————————————————————————————————————————————————————————————————————————————————————• */
    internal static class SolutionProjects
    {
        public static IList<EnvDTE.Project> AllProjects(this Solution solution)
        {
            Projects projects = solution.Projects;
            List<EnvDTE.Project> list = new List<EnvDTE.Project>();
            var item = projects.GetEnumerator();
            while (item.MoveNext())
            {
                var project = item.Current as EnvDTE.Project;
                if (project == null) continue;
                list.AddTopLevelOrNestedProjects(project);
            }
            return list;
        }

        private static void AddTopLevelOrNestedProjects(this List<EnvDTE.Project> list, EnvDTE.Project project)
        {
            if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
            {
                list.AddRange(GetSolutionFolderProjects(project));
            }
            else
            {
                list.Add(project);
            }
        }

        private static IEnumerable<EnvDTE.Project> GetSolutionFolderProjects(EnvDTE.Project solutionFolder)
        {
            List<EnvDTE.Project> list = new List<EnvDTE.Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null) continue;
                list.AddProjectsRecursive(subProject);
            }
            return list;
        }

        private static void AddProjectsRecursive(this List<EnvDTE.Project> list, EnvDTE.Project subProject)
        {
            if (subProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                list.AddRange(GetSolutionFolderProjects(subProject));
            else
                list.Add(subProject);
        }
    }
}
