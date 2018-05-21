using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomation
{
    [TestFixture]
    class Tests
    {
        private static IWebDriver _driver;

        private const string AddOperatorId = "cwbt46";
        private const string SubOperatorId = "cwbt36";

        [Test]
        public void AddOperatorTest()
        {
            var result = CalculateByOperatorId(AddOperatorId);
            Assert.AreEqual(result, "9");
        }

        [Test]
        public void MinusOperatorTest()
        {
            var result = CalculateByOperatorId(SubOperatorId);
            Assert.AreEqual(result, "1");
        }

        private static string CalculateByOperatorId(string operatorId)
        {
            _driver.Url = "http://www.google.com";
            var searchBox = _driver.FindElement(By.Id("lst-ib"));
            searchBox.SendKeys("calculator");
           
            var clik = _driver.FindElements(By.Name("btnK"))[0];
            clik.Submit();

            var fiveButton = _driver.FindElement(By.Id("cwbt24"));
            var operatorBtn = _driver.FindElement(By.Id(operatorId));
            var fourButton = _driver.FindElement(By.Id("cwbt23"));
            var equalButton = _driver.FindElement(By.Id("cwbt45"));

            fiveButton.Click();
            operatorBtn.Click();
            fourButton.Click();
            equalButton.Click();

            var result = _driver.FindElement(By.Id("cwos")).Text;
            return result;
        }

        [OneTimeSetUp]
        public void SetDriver()
        {
            _driver = new ChromeDriver(@"C:\");
        }
    }
}
