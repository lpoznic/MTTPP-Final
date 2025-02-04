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
    public class Register
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
        public void TheRegisterTest()
        {
            driver.Navigate().GoToUrl("https://juice-shop.herokuapp.com/");
            driver.FindElement(By.XPath("//button[@id='navbarAccount']/span/span")).Click();
            driver.FindElement(By.Id("navbarLoginButton")).Click();
            driver.FindElement(By.LinkText("Not yet a customer?")).Click();
            driver.FindElement(By.Id("emailControl")).Click();
            driver.FindElement(By.Id("emailControl")).Clear();
            driver.FindElement(By.Id("emailControl")).SendKeys("examplemail@gmail.com");
            driver.FindElement(By.Id("passwordControl")).Clear();
            driver.FindElement(By.Id("passwordControl")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("repeatPasswordControl")).Clear();
            driver.FindElement(By.Id("repeatPasswordControl")).SendKeys("secret_sauce");
            driver.FindElement(By.XPath("//div[@id='mat-select-value-3']/span")).Click();
            driver.FindElement(By.XPath("//mat-option[@id='mat-option-15']/span")).Click();
            driver.FindElement(By.XPath("//div[@id='registration-form']/div/mat-form-field[2]/div/div/div[3]")).Click();
            driver.FindElement(By.XPath("//div[@id='registration-form']/div/mat-form-field[2]/div/div/div[3]")).Click();
            driver.FindElement(By.Id("securityAnswerControl")).Clear();
            driver.FindElement(By.Id("securityAnswerControl")).SendKeys("Casino Royale");
            driver.FindElement(By.XPath("//button[@id='registerButton']/span")).Click();
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
