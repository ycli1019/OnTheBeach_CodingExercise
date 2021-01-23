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
            JobFactory factory = new JobFactory();
            JobRepository repository = null;

            try 
            {
                repository = factory.readJobsFromConsole();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                Console.Out.WriteLine("Program ends.");
                Console.ReadKey();
                return;
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
