namespace StateMachineCapstone.Contexts
{
    /// <summary>
    /// The <see cref="CourseAdminContext"/> can be used to transition between
    /// states using methods representing actions available to the Course Admin Role.
    /// </summary>
    public class CourseAdminContext : IContext
    {
        public SubjectState SubjectState { get; set; }

        public CourseAdminContext(SubjectState state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(SubjectState state)
        {
            SubjectState = state;
            SubjectState.SetContext(this);
        }

        //The actions available to the Course Admin Role.  
        public void Assign()
        {
            SubjectState.Assign();
        }

        public void Delete()
        {
            SubjectState.Delete();
        }

        public void Submit()
        {
            SubjectState.Submit();
        }

        public void Approve()
        {
            SubjectState.Approve();
        }

        public void Restore()
        {
            SubjectState.Restore();
        }
    }
}
