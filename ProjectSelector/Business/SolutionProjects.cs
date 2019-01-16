namespace ProjectSelector.Business
{
    using EnvDTE;
    using EnvDTE80;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public static class SolutionProjects
    {
        //public static string[] included = new string[] { "Hillavas.Pelikan.Business", "Hillavas.Pelikan.Data", "Hillavas.Pelikan.DI", "Hillavas.Pelikan.Domain", "Hillavas.Pelikan.SharedPreference" };
        
        public static DTE2 GetActiveIDE()
        {
            return (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
        }

        public static IList<ProjectModel> GetProjects()
        {
            Projects projects = GetActiveIDE().Solution.Projects;
            var rep = new List<ProjectModel>();
            var item = projects.GetEnumerator();
            var idx = 0;
            while (item.MoveNext())
            {
                var project = item.Current as Project;
                if (project == null)
                    continue;
                if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    rep.AddRange(
                        GetSolutionFolderProjects(project).Where(x => !Configs.ExcludedProjs.Any(p => p == x.Name)).Select(x => new ProjectModel
                        {
                            Index = ++idx,
                            SolutionFolder = project.Name,
                            Name = x.Name.Split(new char[] { '.' }).Reverse().First(),
                            Path = Directory.GetParent(x.FullName).FullName,
                            Selected = false//included.Any(p => p == x.Name)
                        }));
            }
            return rep;
        }

        private static IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
        {
            List<Project> list = new List<Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                    continue;

                // If this is another solution folder, do a recursive call, otherwise add
                if (subProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    list.AddRange(GetSolutionFolderProjects(subProject));
                else
                    list.Add(subProject);
            }
            return list;
        }
    }
}
