using System;
using System.Collections.Generic;
using System.Text;
using StateMachineCapstone.Contexts;

namespace StateMachineCapstone
{
    /// <summary>
    /// The abstract class which provides the base functionality and contract for a particular <see cref="SubjectState"/>
    /// </summary>
    public abstract class SubjectState
    {
        protected IContext _context;

        public void SetContext(IContext context)
        {
            this._context = context;
        }

        //These are the different actions available to any state.  
        //If an action is not overriden by a particular state and an attempt is made to call the unsupported state
        //an InvalidOperationException is thrown. 
        public virtual void Submit()
        {
            ThrowHelper.ThrowException(nameof(Submit));
        }

        public virtual void Assign()
        {
            ThrowHelper.ThrowException(nameof(Assign));
        }

        public virtual void Delete()
        {
            ThrowHelper.ThrowException(nameof(Delete));
        }

        public virtual void Approve()
        {
            ThrowHelper.ThrowException(nameof(Approve));
        }

        public virtual void Restore()
        {
            ThrowHelper.ThrowException(nameof(Restore));
        }

        public virtual void Grab()
        {
            ThrowHelper.ThrowException(nameof(Grab));
        }
    }
}
