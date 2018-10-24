using System;

namespace core.Board.Exceptions
{
    public class ColumnWIPReachedException : Exception
    {
        public ColumnWIPReachedException(string message) : base(message) { }
    }
}
