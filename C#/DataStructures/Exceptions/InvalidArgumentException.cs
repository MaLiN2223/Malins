using System;

namespace DataStructures.Exceptions
{
    [Serializable]
    internal class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message) : base(message)
        {
        }
    }
}