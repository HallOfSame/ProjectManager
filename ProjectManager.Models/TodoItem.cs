namespace ProjectManager.Models
{
    public enum TodoState
    {
        NotStarted,

        InProgress,

        Done
    }

    public class TodoItem
    {
        #region Constructors

        public TodoItem(TodoState state,
                        string task)
        {
            State = state;
            Task = task;
        }

        #endregion

        #region Instance Properties

        public TodoState State { get; set; }

        public string Task { get; set; }

        #endregion
    }
}