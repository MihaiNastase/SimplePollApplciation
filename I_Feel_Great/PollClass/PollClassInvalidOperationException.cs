using System;
using System.Collections.Generic;
using System.Text;

namespace PollClassLibrary
{/// <summary>
/// Custom exception to hande DivideByZero exception in the case when certain percentages are calculated but there are no responses to begin with.
/// </summary>
    [Serializable]
    public class PollClassInvalidOperationException: Exception
    {
        public PollClassInvalidOperationException()
        : base() {}

        public PollClassInvalidOperationException(string message)
            : base(message){}

    }
}
