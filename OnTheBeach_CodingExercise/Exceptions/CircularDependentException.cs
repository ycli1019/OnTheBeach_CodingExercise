using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class CircularDependentException : Exception
    {
        public CircularDependentException()
        { }

        public CircularDependentException(string message) : base(message)
        { }

        public CircularDependentException(string message, Exception inner) : base(message, inner)
        { }
    }
}
