using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise
{
    public class JobFactory
    {
        public JobFactory()
        { }

        public JobRepository readJobsFromConsole()
        {
            JobInputParser inputParser = new JobInputParser();
            JobRepository repository = new JobRepository();
            List<string> lines = new List<string>();

            Console.Out.WriteLine("Please enter job dependencies (e.g.: a => b and enter, empty line to quit): ");
            while (true)
            {
                bool bQuit = false;

                try
                {
                    string line = Console.ReadLine();
                    if (line.Trim().Equals(string.Empty))
                        bQuit = true;
                    else
                        lines.Add(line);
                    if (bQuit)
                        break;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }

            foreach (string line in lines)
            {
                try
                {
                    Job job = inputParser.getInput(line);
                    repository.addJob(job);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return repository;
        }

        public JobRepository readJobsFromTextFile(string path)
        {
            JobInputParser inputParser = new JobInputParser();
            JobRepository repository = new JobRepository();
            List<string> lines = new List<string>();

            try
            {
                lines = System.IO.File.ReadAllLines(path).ToList();
                lines = lines.Where(item => !item.Trim().Equals(string.Empty)).Select(item => { item = item.Trim(); return item; }).ToList();
            }
            catch (Exception ex)
            { throw ex; }

            foreach (string line in lines)
            {
                try
                {
                    Job job = inputParser.getInput(line);
                    repository.addJob(job);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return repository;
        }
    }
}
