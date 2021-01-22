using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // interactive design, will return the sequence after each line of input
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
                    Console.Out.WriteLine(ex.Message);
                    Console.Out.WriteLine("Program ends.");
                    Console.ReadKey();
                    return;
                }
            }

            try
            {
                Console.WriteLine("Dependency: " + repository.showDependancies());
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                Console.Out.WriteLine("Program ends.");
                Console.ReadKey();
                return;
            }
            
            Console.Out.WriteLine("Program ends.");
            Console.ReadKey();
        }
    }
}
