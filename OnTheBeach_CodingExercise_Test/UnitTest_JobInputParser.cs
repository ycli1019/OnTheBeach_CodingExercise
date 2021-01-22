using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OnTheBeach_CodingExercise;
using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise_Test
{
    [TestClass]
    public class UnitTest_JobInputParser
    {
        [TestMethod]
        public void Test_DependentJob()
        {
            string line = "a => b";
            JobInputParser parser = new JobInputParser();
            Job job = parser.getInput(line);
            Console.WriteLine(job.ToString());

            Assert.AreEqual("OnTheBeach_CodingExercise.Models.DependentJob; Job Name: a; Next Job Name: b", job.ToString());
        }

        [TestMethod]
        public void Test_IndependentJob()
        {
            string line = "a => ";
            JobInputParser parser = new JobInputParser();
            Job job = parser.getInput(line);
            Console.WriteLine(job.ToString());

            Assert.AreEqual("OnTheBeach_CodingExercise.Models.IndependentJob; Job Name: a", job.ToString());
        }

        [TestMethod]
        public void Test_InvalidDependencySign1()
        {
            string line = "a b c";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Invalid dependency sign");
            }
        }

        [TestMethod]
        public void Test_InvalidDependencySign2()
        {
            string line = "=> b";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Invalid dependency sign");
            }
        }

        [TestMethod]
        public void Test_InvalidFormat()
        {
            string line = "a => b c";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Invalid job dependency format");
            }
        }

        [TestMethod]
        public void Test_InvalidJobName()
        {
            string line = "ab => c";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Invalid job name");
            }
        }

        [TestMethod]
        public void Test_InvalidNextJobName()
        {
            string line = "a => bc";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Invalid next job name.");
            }
        }

        [TestMethod]
        public void Test_SelfDependent1()
        {
            string line = "a => b";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Self-dependent");
            }
        }

        [TestMethod]
        public void Test_SelfDependent2()
        {
            string line = "b => b";
            JobInputParser parser = new JobInputParser();
            try
            {
                Job job = parser.getInput(line);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Self-dependent");
            }
        }
    }
}
