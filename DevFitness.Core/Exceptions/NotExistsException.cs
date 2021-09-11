using System;

namespace DevFitness.Core.Exceptions
{
    public class NotExistsException : Exception
    {
        public NotExistsException(string message = "The requested record was not found") : base(message)
        {
        }        
    }
}