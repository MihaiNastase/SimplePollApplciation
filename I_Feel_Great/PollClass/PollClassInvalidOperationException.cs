using System;
using System.Collections.Generic;
using System.Text;

namespace PollClassLibrary
{/// <summary>
/// Custom exception to hande DivideByZero exception in the case when certain percentages are calculate but there are no responses to begin with.
/// </summary>
    [Serializable]
    class PollClassInvalidOperationException: Exception
    {
        public PollClassInvalidOperationException()
        : base() {}

        public PollClassInvalidOperationException(string message)
            : base(message){}

    }
}
