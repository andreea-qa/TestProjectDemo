using OpenQA.Selenium;
using TestProject.Common.Enums;
using TestProject.SDK;
using TestProject.SDK.Reporters;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace NUnitTestProject1
{
    public class LogInTest : IWebTest
    {
  
        ExecutionResult IWebTest.Execute(WebTestHelper helper)
        {
            var driver = helper.Driver;
            TestReporter report = helper.Reporter;

            //open the https://example.testproject.io/web/ webpage
            driver.Navigate().GoToUrl("https://example.testproject.io/web/");

            //Fill in the form with the username and password
            driver.FindElementById("name").SendKeys("John Smith");
            driver.FindElementById("password").SendKeys("12345");
            driver.FindElementById("login").Click();
            helper.Reporter.Step("Logged in the app", "The login is unsuccessful", "The login is successful", 
                driver.FindElement(By.Id("logout")).Displayed, TakeScreenshotConditionType.Failure);

            //Verify that the login was successful 
            if (driver.FindElement(By.Id("logout")).Displayed)
            {
                return ExecutionResult.Passed;
            } else
            {
                return ExecutionResult.Failed;
            }
                          
        }
    }
}