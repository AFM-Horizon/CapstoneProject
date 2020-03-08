using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineCapstone.States
{
    /// <summary>
    /// <para></para>
    /// <para>A concrete implementation of <see cref="SubjectState"/>.</para>
    /// Encapsulates the logic of which other states can be transitioned to from the <see cref="Deleted"/> state.
    /// </summary>
    public class Deleted : SubjectState
    {
        public override void Restore()
        {
            _context.TransitionTo(new Restored());
        }
    }
}
