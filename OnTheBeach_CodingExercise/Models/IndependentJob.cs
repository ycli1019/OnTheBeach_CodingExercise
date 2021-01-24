using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnTheBeach_CodingExercise.Exceptions;

// IndependentJob: implements Job
namespace OnTheBeach_CodingExercise.Models
{
    public class IndependentJob: Job
    {
        private readonly char _jobName;
        public IndependentJob(char jobName)
        {
            _jobName = jobName;
        }

        public override char getJobName()
        {
            return _jobName;
        }
        public override char getNextJobName()
        {
            throw new IndependentJobException("Next job does not exist in independent jobs.");
        }
        public override string ToString()
        {
            return string.Format("{0}; Job Name: {1}", GetType().ToString(), _jobName);
        }
    }
}
