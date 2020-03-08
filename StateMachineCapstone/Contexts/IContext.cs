namespace StateMachineCapstone.Contexts
{
    /// <summary>
    /// An interface for a context class which encapsulates the methods that are available to a particular user within the state machine
    /// </summary>
    public interface IContext
    {
        SubjectState SubjectState { get; set; }

        void TransitionTo(SubjectState state);
    }
}
