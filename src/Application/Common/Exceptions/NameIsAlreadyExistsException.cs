using System;

namespace Clean_Architecture_Task.Application.Common.Exceptions
{
    public class NameIsAlreadyExistsException : Exception
    {
        public NameIsAlreadyExistsException(string action, string name, object key, string message= "Name Is already exists")
            : base($"{action} entity \"{name}\" ({key}) failed. {message}")
        {

        }
    }
}
