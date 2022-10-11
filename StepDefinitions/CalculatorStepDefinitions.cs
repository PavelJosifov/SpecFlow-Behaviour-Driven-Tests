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
        private const string SiteUrl = "https://js-calculator.nakov.repl.co/";
        public static IWebDriver driver;
        static IWebElement textBox1;
        static IWebElement textBox2;
        static SelectElement dropDownOperation;
        static IWebElement textBox;
        static IWebElement ResetButton;
        static IWebElement ButtonCalculate;
        [BeforeFeature]

        public static void OpenTheApp()

        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(SiteUrl);
            var linkNumberCalc = driver.FindElement(By.CssSelector("body > header > a:nth-child(2)"));
            linkNumberCalc.Click();
            textBox1 = driver.FindElement(By.Id("number1"));
            textBox2 = driver.FindElement(By.Id("number2"));
            dropDownOperation = new SelectElement(driver.FindElement(By.Id("operation")));
            ButtonCalculate = driver.FindElement(By.CssSelector("#screenNumberCalc > form > div.buttons-bar > input[type=button]:nth-child(1)"));
            ResetButton = driver.FindElement(By.CssSelector("#screenNumberCalc > form > div.buttons-bar > input[type=reset]:nth-child(2)"));
        }

        [AfterFeature]
        public static void CloseCalculatorApp()

        {
            driver.Quit();
        }

        [BeforeScenario]

        public static void CalculatorReset()
        {
            ResetButton.Click();
        }

        [Given("the first number is (.*)")]
        public static void GivenTheFirstNumberIs(string firstnum)
        {
            textBox1.SendKeys(firstnum);
        }

        [Given("the second number is (.*)")]
        public static void GivenTheSecondNumberIs(string secondnum)
        {
            textBox2.SendKeys(secondnum);
        }

        [When("the two numbers are (.*)")]
        public static void WhenTheTwoNumbersAreAdded(string operation)
        {
            switch (operation)
            {
                case "added":
                    dropDownOperation.SelectByValue("+");
                    break;
                case "subtracted":
                    dropDownOperation.SelectByValue("-");
                    break;
                case "divided":
                    dropDownOperation.SelectByValue("/");
                    break;
                case "multiplied":
                    dropDownOperation.SelectByValue("*");
                    break;
                default:
                    throw new InvalidOperationException($"Operation {operation} not supported by the app");
            }
            ButtonCalculate.Click();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedresult)
        {
            var result = driver.FindElement(By.CssSelector("#screenNumberCalc > div")).Text;
            result = result.Substring("Result: ".Length);
            Thread.Sleep(800);
            result.Should().Be(expectedresult);
        }
    }
}