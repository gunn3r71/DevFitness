using System;

namespace DevFitness.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message = "One or more validation errors occurred, check the data entered") : base(message)
        {
        }
    }
}