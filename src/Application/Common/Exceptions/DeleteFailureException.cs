using System;

namespace Clean_Architecture_Task.Application.Common.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string message)
            : base($"{message}")
        {
        }
    }
}
