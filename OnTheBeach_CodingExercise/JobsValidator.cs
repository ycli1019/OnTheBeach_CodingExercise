using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise
{
    public class JobsValidator
    {
        private readonly List<Job> _jobs;

        public JobsValidator(List<Job> jobs)
        {
            _jobs = jobs; 
        }

        public void checkMultipleJobName()
        {
            foreach (Job j in _jobs)
            {
                if (_jobs.Count(item => j.getJobName().Equals(item.getJobName())) >= 2)
                    throw new ArgumentException(string.Format("Multiple entries of a single job name is not supported. ({0})", j.getJobName()));
            }
        }

        public void checkUnspecifiedNextJob()
        {
            foreach (Job j in _jobs)
            {
                try
                {
                    if (_jobs.Count(item => j.getNextJobName().Equals(item.getJobName())) <= 0)
                        throw new ArgumentException(string.Format("Unspecified job found. ({0})", j.getNextJobName()));
                }
                catch (InvalidOperationException ex)
                {
                    //Independent Job
                    // Do nothing
                }
            }
        }

        public void checkCircularDependent()
        {
            foreach (Job j in _jobs)
            {
                if (checkJobCircularDependent(j, new List<char>()))
                    throw new ArgumentException("Circular dependency is not allowed.");
            }
        }
        private bool checkJobCircularDependent(Job job, List<char> checkedJobNames)
        {
            try
            {
                Job nextJob = _jobs.FirstOrDefault(item => item.getJobName().Equals(job.getNextJobName()));
                if (checkedJobNames.Contains(nextJob.getJobName()))
                    return true;
                else
                {
                    checkedJobNames.Add(nextJob.getJobName());
                    return checkJobCircularDependent(nextJob, checkedJobNames);
                }
            }
            catch (InvalidOperationException ex)
            {
                // Independent Job
                return false;
            }
        }
    }
}
