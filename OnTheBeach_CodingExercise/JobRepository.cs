using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise
{
    public class JobRepository
    {
        private List<Job> _jobs = new List<Job>();

        public JobRepository()
        {
        }

        public void addJob(Job job)
        {
            _jobs.Add(job);
        }
        public JobsValidator CreateValidator()
        {
            return new JobsValidator(_jobs);
        }


        public string showDependancies()
        {
            JobsValidator validator = CreateValidator();
            try
            {
                validator.checkUnspecifiedNextJob();
                validator.checkMultipleJobName();
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string result = string.Empty;
            // Bottom-up approach.
            List<char> sortedJobsInReverseOrder = new List<char>();
            foreach (Job job in _jobs)
            {
                try
                {
                    char temp = job.getNextJobName();
                }
                catch (InvalidOperationException ex)
                {
                    //Starting with independent job
                    showJobDependencies(job, sortedJobsInReverseOrder);
                }
            }
            for (int i = sortedJobsInReverseOrder.Count-1; i >= 0; i--)
            {
                if (result.Equals(string.Empty))
                    result = sortedJobsInReverseOrder[i].ToString();
                else
                    result = string.Format("{0}, {1}", result, sortedJobsInReverseOrder[i].ToString());
            }
            return result;
        }

        private void showJobDependencies(Job job, List<char> list)
        {
            List<Job> js = new List<Job>();
            foreach(Job j in _jobs)
            {
                try
                {
                    if (job.getJobName().Equals(j.getNextJobName()))
                        js.Add(j);
                }
                catch (InvalidOperationException ex)
                { 
                    // IndependentJob
                    // Do nothing
                }
            }

            if(!list.Contains(job.getJobName()))
                list.Add(job.getJobName());
            foreach (Job j in js)
            {
                showJobDependencies(j, list);
            }
        }
    }
}
