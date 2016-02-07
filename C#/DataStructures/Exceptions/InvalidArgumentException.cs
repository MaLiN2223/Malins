namespace DataStructures.Exceptions
{
    using System;

    [Serializable]
    internal class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message) : base(message)
        {
        }
    }
}