using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProjectAutomatedTests.StepDefinitions
{
    [Binding, Scope(Feature = "MetricCalculator")]
    public class MetricCalculatorStepDefinitions
    {

        public static IWebDriver driver;
        static IWebElement textBoxInputValue;
        static SelectElement dropDownSourceMetric;
        static SelectElement dropDownDestinationMetric;
        static IWebElement ResetButton;
        static IWebElement ButtonCalculate;
        [BeforeFeature]

        public static void OpenTheApp()

        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://js-calculator.nakov.repl.co/");
            var linkMetricCalc = driver.FindElement(By.CssSelector("body > header > a:nth-child(3)"));
            linkMetricCalc.Click();
            textBoxInputValue = driver.FindElement(By.CssSelector("input#fromValue"));
            dropDownSourceMetric = new SelectElement(driver.FindElement(By.CssSelector("#sourceMetric")));
            dropDownDestinationMetric = new SelectElement(driver.FindElement(By.CssSelector("#destMetric")));
            ButtonCalculate = driver.FindElement(By.CssSelector("#screenMetricCalc > form > div.buttons-bar > input[type=button]:nth-child(1)"));
            ResetButton = driver.FindElement(By.CssSelector("#screenMetricCalc > form > div.buttons-bar > input[type=reset]:nth-child(2)"));
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

        [Given("input value is (.*)")]
        public static void GivenTheInputValueIs(string inputValue)
        {
            textBoxInputValue.SendKeys(inputValue);
        }

        [Given("the source metric is \"(.*)\"")]
        public static void GivenTheSourceMetricIs(string sourcemetric)
        {
            dropDownSourceMetric.SelectByValue(sourcemetric);
        }

        [Given("the destination metric is \"(.*)\"")]
        public static void GivenTheDestinationMetricIs(string destinationmetric)
        {
            dropDownDestinationMetric.SelectByValue(destinationmetric);
        }


        [When("the conversion is performed")]
        public static void WhenTheConversionIsPErformed()
        { 
            ButtonCalculate.Click();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedresult)
        {
            var result = driver.FindElement(By.CssSelector("#screenMetricCalc > div")).Text;
            result = result.Substring("Result: ".Length);
            Thread.Sleep(800);
            result.Should().Be(expectedresult);
        }
    }
}