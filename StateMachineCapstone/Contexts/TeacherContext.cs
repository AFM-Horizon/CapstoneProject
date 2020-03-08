namespace StateMachineCapstone.Contexts
{
    /// <summary>
    /// The <see cref="TeacherContext"/> can be used to transition between
    /// states using methods representing actions available to the Teacher role.
    /// </summary>
    public class TeacherContext : IContext
    {
        public SubjectState SubjectState { get; set; }

        public TeacherContext(SubjectState state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(SubjectState state)
        {
            SubjectState = state;
            SubjectState.SetContext(this);
        }

        //The actions available to the Teacher Role
        public void Submit()
        {
            SubjectState.Submit();
        }

        public void Grab()
        {
            SubjectState.Grab();
        }
    }
}
