using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OnTheBeach_CodingExercise;
using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise_Test
{
    [TestClass]
    public class UnitTest_JobsValidator
    {
        [TestMethod]
        public void Test_checkMultipleJobName1()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'd')); // c => d 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new IndependentJob('e')); // e => 

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkMultipleJobName();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //StringAssert.Contains(ex.Message, "Multiple entries of a single job name is not supported.");
            }
        }

        [TestMethod]
        public void Test_checkMultipleJobName2()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('a', 'c')); // a => c 
            repository.addJob(new DependentJob('b', 'd')); // b => d 
            repository.addJob(new DependentJob('c', 'e')); // c => e 
            repository.addJob(new IndependentJob('d')); // d => 
            repository.addJob(new IndependentJob('e')); // e => 

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkMultipleJobName();
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Multiple entries of a single job name is not supported.");
            }
        }

        [TestMethod]
        public void Test_checkUnspecifiedNextJob1()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'd')); // c => d 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new IndependentJob('e')); // e => 

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkUnspecifiedNextJob();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //StringAssert.Contains(ex.Message, "Unspecified job found.");
            }
        }

        [TestMethod]
        public void Test_checkUnspecifiedNextJob2()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('a', 'c')); // a => c 
            repository.addJob(new DependentJob('b', 'd')); // b => d 
            repository.addJob(new DependentJob('c', 'e')); // c => e 
            repository.addJob(new IndependentJob('d')); // d => 

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkUnspecifiedNextJob();
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Unspecified job found.");
            }
        }

        [TestMethod]
        public void Test_checkCircularDependent1()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'd')); // c => d 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new IndependentJob('e')); // e => 

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //StringAssert.Contains(ex.Message, "Circular dependency is not allowed");
            }
        }

        [TestMethod]
        public void Test_checkCircularDependent2()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'd')); // c => d 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new DependentJob('e', 'a')); // e => a

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Circular dependency is not allowed");
            }
        }

        [TestMethod]
        public void Test_checkCircularDependent3()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new IndependentJob('c')); // c => 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new IndependentJob('e')); // e =>

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //StringAssert.Contains(ex.Message, "Circular dependency is not allowed");
            }
        }

        [TestMethod]
        public void Test_checkCircularDependent4()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new DependentJob('a', 'b')); // a => b 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'a')); // c => a 
            repository.addJob(new DependentJob('d', 'e')); // d => e 
            repository.addJob(new IndependentJob('e')); // e =>

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Circular dependency is not allowed");
            }
        }

        [TestMethod]
        public void Test_checkCircularDependent5()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new IndependentJob('a')); // a => 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'f')); // c => f
            repository.addJob(new DependentJob('d', 'a')); // d => a 
            repository.addJob(new IndependentJob('e')); // e =>
            repository.addJob(new DependentJob('f', 'b')); // f => b

            JobsValidator validator = repository.CreateValidator();

            try
            {
                validator.checkCircularDependent();
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Circular dependency is not allowed");
            }
        }
    }
}
