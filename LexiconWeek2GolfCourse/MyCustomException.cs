using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconWeek2GolfCourse
{
    public class MyCustomException : Exception
    {
        public MyCustomException()
        {
        }

        public MyCustomException(string message)
            : base(message)
        {
        }

        public MyCustomException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
