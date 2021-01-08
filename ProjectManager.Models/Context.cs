using System.Collections.Generic;

namespace ProjectManager.Models
{
    public class Context
    {
        #region Constructors

        public Context()
        {
            Projects = new List<Project>();
            TimeSlots = new List<TimeSlot>();
        }

        #endregion

        #region Instance Properties

        public List<Project> Projects { get; }

        public List<TimeSlot> TimeSlots { get; }

        #endregion
    }
}