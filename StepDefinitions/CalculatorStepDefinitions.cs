using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProjectAutomatedTests.StepDefinitions
{
    [Binding, Scope(Feature = "Calculator")]
    public class CalculatorStepDefinitions
    {

        public static IWebDriver driver;

        [BeforeFeature]

        public static void OpenTheApp()

        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://js-calculator.nakov.repl.co/");
            var linkNumberCalc = driver.FindElement(By.CssSelector("body > header > a:nth-child(2)"));
            linkNumberCalc.Click();


        }

        [AfterFeature]
        public static void CloseCalculatorApp()

        {
            driver.Quit();

        }

        [BeforeScenario]

        public static void ResetButton()
        {

            var buttonReset = driver.FindElement(By.CssSelector("#screenNumberCalc > form > div.buttons-bar > input[type=reset]:nth-child(2)"));
            buttonReset.Click();
        }

        [Given("the first number is (.*)")]
        public static void GivenTheFirstNumberIs(string firstnum)
        {
            driver.FindElement(By.Id("number1")).SendKeys(firstnum);
        }

        [Given("the second number is (.*)")]
        public static void GivenTheSecondNumberIs(string secondnum)
        {
            driver.FindElement(By.Id("number2")).SendKeys(secondnum);
        }

        [When("the two numbers are (.*)")]
        public static void WhenTheTwoNumbersAreAdded(string operation)
        {
            var dropDownOperation =
                new SelectElement(driver.FindElement(By.Id("operation")));
            if (operation == "added")
                dropDownOperation.SelectByValue("+");
            else if (operation == "subtracted")
                dropDownOperation.SelectByValue("-");
            else if (operation == "divided")
                dropDownOperation.SelectByValue("/");
            else if (operation == "multiplied")
                dropDownOperation.SelectByValue("*");
            else
                throw new System.InvalidOperationException($"Operation{operation} not supported by the app");
            var buttonCalc = driver.FindElement(By.CssSelector("#screenNumberCalc > form > div.buttons-bar > input[type=button]:nth-child(1)"));
            

            buttonCalc.Click();
            


        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedresult)
        {

            var result = driver.FindElement(By.CssSelector("#screenNumberCalc > div")).Text;
            result = result.Substring("Result: ".Length);
            result.Should().Be(expectedresult);
            
            //Assert.AreEqual(expectedresult, result);
        }
    }
}