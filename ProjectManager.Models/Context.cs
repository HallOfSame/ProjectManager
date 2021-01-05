using System.Collections.Generic;

namespace ProjectManager.Models
{
    public class Context
    {
        #region Constructors

        public Context()
        {
            Projects = new List<Project>();
        }

        #endregion

        #region Instance Properties

        public List<Project> Projects { get; }

        #endregion
    }
}