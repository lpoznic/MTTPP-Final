using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class CustomerFeedback
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCustomerFeedbackTest()
        {
            driver.Navigate().GoToUrl("https://juice-shop.herokuapp.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='v17.1.1'])[1]/following::mat-icon[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='feedback'])[1]/following::span[1]")).Click();
            driver.FindElement(By.Id("comment")).Click();
            driver.FindElement(By.Id("comment")).Clear();
            driver.FindElement(By.Id("comment")).SendKeys("Overall, my experience was [describe experience—positive, negative, or mixed]. I particularly appreciated [mention what you liked, e.g., great customer service,");
            driver.FindElement(By.Id("rating")).Click();
            driver.FindElement(By.Id("captchaControl")).Click();
            driver.FindElement(By.Id("captchaControl")).Click();
            driver.FindElement(By.Id("captchaControl")).Clear();
            driver.FindElement(By.Id("captchaControl")).SendKeys("2");
            driver.FindElement(By.XPath("//button[@id='submitButton']/span")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
