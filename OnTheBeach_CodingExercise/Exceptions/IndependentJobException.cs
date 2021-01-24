using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class IndependentJobException: Exception
    {
        public IndependentJobException()
        { }

        public IndependentJobException(string message) : base(message)
        { }

        public IndependentJobException(string message, Exception inner) : base(message, inner)
        { }
    }
}
