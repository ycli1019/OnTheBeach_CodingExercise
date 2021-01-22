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

            while(true)
            {
                bool bQuit = false;

                try
                {
                    Console.Out.Write("Please enter a job dependency (e.g.: a => b, Enter to quit): ");
                    string line = Console.ReadLine();
                    if (line.Trim().Equals(string.Empty))
                        bQuit = true;
                    Job job = inputParser.getInput(line);
                    if (bQuit)
                        break;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }

            Console.Out.WriteLine("Program ends.");
        }
    }
}
