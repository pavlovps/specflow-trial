using System;

namespace core.Board.Exceptions
{
    public class EmptyReleaseException : Exception
    {
        public EmptyReleaseException(string message) : base(message) { }
    }
}
