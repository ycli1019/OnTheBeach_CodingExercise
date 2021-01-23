using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OnTheBeach_CodingExercise;
using OnTheBeach_CodingExercise.Models;
using System.Reflection;

using System.IO;

namespace OnTheBeach_CodingExercise_Test
{
    [TestClass]
    public class UnitTest_JobFactory
    {
        [TestMethod]
        public void Test_readJobsFromConsole()
        {
            JobFactory factory = new JobFactory();
            StringReader input = new StringReader("a => b" + Environment.NewLine + "b =>" + Environment.NewLine + Environment.NewLine);
            Console.SetIn(input);
            JobRepository repository = factory.readJobsFromConsole();
            string result = repository.ToString();
            StringAssert.Contains(result,
                "OnTheBeach_CodingExercise.Models.DependentJob; Job Name: a; Next Job Name: b" + Environment.NewLine + "OnTheBeach_CodingExercise.Models.IndependentJob; Job Name: b");

        }
        [TestMethod]
        public void Test_readJobsFromFile()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TextFile1.txt";
            JobFactory factory = new JobFactory();
            JobRepository repository = factory.readJobsFromTextFile(path);
            string result = repository.ToString();
            StringAssert.Contains(result,
                "OnTheBeach_CodingExercise.Models.DependentJob; Job Name: a; Next Job Name: b" + Environment.NewLine + "OnTheBeach_CodingExercise.Models.IndependentJob; Job Name: b");

        }
    }
}
