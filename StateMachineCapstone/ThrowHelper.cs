using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineCapstone
{
    /// <summary>
    /// A simple encapsulation of the <see cref="InvalidOperationException"/> to allow ease of use.
    /// </summary>
    public static class ThrowHelper
    {
        public static void ThrowException(string operationName)
        {
            throw new InvalidOperationException($"The action {operationName} is not valid in the current state.");
        }
    }
}
