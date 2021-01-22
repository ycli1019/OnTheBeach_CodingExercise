using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract Class of Job: Dependent Job and IndependentJob
namespace OnTheBeach_CodingExercise.Models
{
    public abstract class Job
    {
        public abstract char getJobName();
        public abstract char getNextJobName();
        public abstract override string ToString();
    }

}
