using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class SelfDependentException: Exception 
    {
        public SelfDependentException()
        { }

        public SelfDependentException(string message) : base(message)
        { }

        public SelfDependentException(string message, Exception inner) : base(message, inner)
        { }
    }
}
