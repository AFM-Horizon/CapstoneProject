using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineCapstone.States
{
    /// <summary>
    /// <para></para>
    /// <para>A concrete implementation of <see cref="SubjectState"/>.</para>
    /// Encapsulates the logic of which other states can be transitioned to from the <see cref="Restored"/> state.
    /// </summary>
    public class Restored : SubjectState
    {
        public override void Assign()
        {
            _context.TransitionTo(new InProgress());
        }

        public override void Delete()
        {
            _context.TransitionTo(new Deleted());
        }
    }
}
