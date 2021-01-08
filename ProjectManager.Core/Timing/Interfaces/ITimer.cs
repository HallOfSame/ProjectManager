using System;

using ProjectManager.Models;

namespace ProjectManager.Core.Timing.Interfaces
{
    public interface ITimer
    {
        #region Instance Properties

        TimeSpan CurrentElapsedTime { get; }

        #endregion

        #region Instance Methods

        void StartTiming(Project project);

        void StopTiming();

        void SwitchToNewProject(Project newProject);

        #endregion
    }
}