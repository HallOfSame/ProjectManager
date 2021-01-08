using System;

namespace ProjectManager.Models
{
    public class TimeSlot
    {
        #region Constructors

        public TimeSlot(Project associatedProject,
                        DateTime start)
        {
            AssociatedProject = associatedProject;
            Start = start;
        }

        #endregion

        #region Instance Properties

        public Project AssociatedProject { get; set; }

        public DateTime End
        {
            get
            {
                return Start + Length;
            }
        }

        public TimeSpan Length { get; set; }

        public DateTime Start { get; set; }

        #endregion
    }
}