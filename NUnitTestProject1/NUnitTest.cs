using NUnit.Framework;
using TestProject.Common.Enums;
using TestProject.SDK;
using System;

namespace NUnitTestProject1
{
    public class NUnitTest1
    {
        Runner runner;
        private string DevToken = Environment.GetEnvironmentVariable("TP_DEV_TOKEN");


        [OneTimeSetUp]
        public void SetUp()
        {
            
            runner = new RunnerBuilder(DevToken).AsWeb(AutomatedBrowserType.Chrome).Build();
        }

        [Test]
        public void Login()
        {
            
           runner.Run(new LogInTest());
        }

        //[Test]
        public void TestInvalidLogin()
        {
            runner.Run(new LogInTest());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            runner.Dispose();
            
        }
    }
}