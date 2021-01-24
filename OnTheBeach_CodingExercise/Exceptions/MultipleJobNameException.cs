using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class MultipleJobNameException: Exception
    {
        public MultipleJobNameException()
        { }

        public MultipleJobNameException(string message) : base(message)
        { }

        public MultipleJobNameException(string message, Exception inner) : base(message, inner)
        { }
    }
}
