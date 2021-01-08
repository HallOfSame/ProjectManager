using System;
using System.Diagnostics;

using ProjectManager.Core.Timing.Interfaces;
using ProjectManager.Models;

namespace ProjectManager.Core.Timing
{
    public class Timer : ITimer
    {
        #region Fields

        private readonly Stopwatch currentTaskStopwatch;

        private TimeSlot currentTimeSlot;

        #endregion

        #region Constructors

        public Timer(Stopwatch currentTaskStopwatch)
        {
            this.currentTaskStopwatch = currentTaskStopwatch;
        }

        #endregion

        #region Instance Properties

        public TimeSpan CurrentElapsedTime
        {
            get
            {
                return currentTaskStopwatch.Elapsed;
            }
        }

        #endregion

        #region Instance Methods

        public void StartTiming(Project project)
        {
            currentTimeSlot = new TimeSlot(project, DateTime.UtcNow);
            currentTaskStopwatch.Start();
        }

        public void StopTiming()
        {
            var now = DateTime.UtcNow;

            var length = now - currentTimeSlot.Start;

            currentTimeSlot.Length = length;

            currentTaskStopwatch.Stop();

            // TODO persist this time slot
        }

        public void SwitchToNewProject(Project newProject)
        {
            StopTiming();
            StartTiming(newProject);
        }

        #endregion
    }
}