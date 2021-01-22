using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach_CodingExercise.Models
{
    class DependentJob: Job
    {
        private readonly char _jobName;
        private readonly char _nextJobName;
        public DependentJob(char jobName, char nextJobName)
        {
            _jobName = jobName;
            _nextJobName = nextJobName;
        }

        public override char getJobName()
        {
            return _jobName;
        }
        public override char getNextJobName()
        {
            return _nextJobName;
        }

        public override string ToString()
        {
            return string.Format("{0}; Job Name: {1}; Next Job Name: {2}", GetType().ToString(), _jobName, _nextJobName);
        }
    }
}
