using System.Collections.Generic;

namespace ProjectManager.Models
{
    public class Project
    {
        #region Constructors

        public Project(string name)
        {
            ProjectName = name;
            TodoList = new List<TodoItem>();
        }

        #endregion

        #region Instance Properties

        public string ProjectName { get; set; }

        public List<TodoItem> TodoList { get; set; }

        #endregion
    }
}