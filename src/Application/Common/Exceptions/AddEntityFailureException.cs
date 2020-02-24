using System;

namespace Clean_Architecture_Task.Application.Common.Exceptions
{
    public class AddEntityFailureException : Exception
    {
        public AddEntityFailureException (string entityName, Exception ex)
            : base($"Entity: {entityName} not saved to database", ex)
        {
        }
    }
}
