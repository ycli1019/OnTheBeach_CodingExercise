using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Exceptions
{
    public class UnspecifiedNextJobException: Exception
    {
        public UnspecifiedNextJobException()
        { }

        public UnspecifiedNextJobException(string message) : base(message)
        { }

        public UnspecifiedNextJobException(string message, Exception inner) : base(message, inner)
        { }
    }
}
