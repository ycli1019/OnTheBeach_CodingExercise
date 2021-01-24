using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

using OnTheBeach_CodingExercise.Models;
using OnTheBeach_CodingExercise.Exceptions;

// Read console input and return job name and next job name
namespace OnTheBeach_CodingExercise
{
    public class JobInputParser
    {
        public JobInputParser()
        { 
        }

        // Return true if end of stream; 
        public Job getInput(string line)
        {
            char jobName = '-';
            char nextJobName = '-';
            string[] lineComponents = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            //Validate dependency sign here.
            if (lineComponents.Count(item => item.Equals("=>")) != 1 || !lineComponents[1].Equals("=>"))
                throw new JobParseException("Invalid dependency sign (=>).");

            // Validate dependency string
            if (lineComponents.Length > 3)
                throw new JobParseException("Invalid job dependency format.");

            // Validate job name
            Regex alphabetPattern = new Regex("^[a-zA-Z]{1}$");
            if (!alphabetPattern.IsMatch(lineComponents[0]))
                throw new JobParseException("Invalid job name.");
            else
                jobName = char.Parse(lineComponents[0]);

            // Validate next job name
            if (lineComponents.Length <= 2)
                return new IndependentJob(jobName);
            else if (!alphabetPattern.IsMatch(lineComponents[2]))
                throw new JobParseException("Invalid next job name.");
            else
            {
                nextJobName = char.Parse(lineComponents[2]);
                if (jobName.Equals(nextJobName))
                    throw new SelfDependentException("Self-dependent.");
                return new DependentJob(jobName, nextJobName);
            }
        }
    }
}
