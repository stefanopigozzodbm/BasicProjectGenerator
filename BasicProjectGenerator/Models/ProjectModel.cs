using System.IO;

namespace Basic_Project_Generator.Models
{
    public class ProjectModel
    {
        #region properties

        public string Name
        {
            get;
            set;
        }

        public DirectoryInfo TargetDirectory
        {
            get;
            set;
        }

        #endregion // properties
    }
}
