using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class JobParseException : Exception
    {
        public JobParseException()
        { }

        public JobParseException(string message) : base(message)
        { }

        public JobParseException(string message, Exception inner) : base(message, inner)
        { }
    }
}
