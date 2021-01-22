using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OnTheBeach_CodingExercise;
using OnTheBeach_CodingExercise.Models;

namespace OnTheBeach_CodingExercise_Test
{
    [TestClass]
    public class UnitTest_JobRepository
    {
        [TestMethod]
        public void Test_showDependencies1()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new IndependentJob('a')); // a => 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'a')); // c => a

            string result = repository.showDependancies();
            Assert.AreEqual("b, c, a", result);
        }

        [TestMethod]
        public void Test_showDependencies2()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new IndependentJob('a')); // a => 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'f')); // c => f
            repository.addJob(new DependentJob('d', 'a')); // d => a
            repository.addJob(new DependentJob('e', 'b')); // e => b 
            repository.addJob(new IndependentJob('f')); // f =>
            string result = repository.showDependancies();
            Assert.AreEqual("e, b, c, f, d, a", result);
        }

        [TestMethod]
        public void Test_showDependencie3()
        {
            JobRepository repository = new JobRepository();
            repository.addJob(new IndependentJob('a')); // a => 
            repository.addJob(new DependentJob('b', 'c')); // b => c 
            repository.addJob(new DependentJob('c', 'f')); // c => f
            repository.addJob(new DependentJob('d', 'c')); // d => a
            repository.addJob(new DependentJob('e', 'b')); // e => b 
            repository.addJob(new IndependentJob('f')); // f =>
            string result = repository.showDependancies();
            Assert.AreEqual("d, e, b, c, f, a", result);
        }
    }
}
