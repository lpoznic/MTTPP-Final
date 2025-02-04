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
    public class AddToCart
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
        public void TheAddToCartTest()
        {
            driver.Navigate().GoToUrl("https://juice-shop.herokuapp.com/");
            driver.FindElement(By.XPath("//button[@id='navbarAccount']/span/span")).Click();
            driver.FindElement(By.XPath("//button[@id='navbarLoginButton']/span")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("examplemail@gmail.com");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("loginButton")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Apple Juice (1000ml)'])[1]/following::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Apple Pomace'])[1]/following::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Banana Juice (1000ml)'])[1]/following::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Account'])[2]/following::span[4]")).Click();
            driver.FindElement(By.Id("checkoutButton")).Click();
            driver.FindElement(By.XPath("//div[@id='card']/app-address/mat-card/div/button/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='address-form']/mat-form-field/div/div/div[3]")).Click();
            driver.FindElement(By.Id("mat-input-3")).Click();
            driver.FindElement(By.Id("mat-input-3")).Clear();
            driver.FindElement(By.Id("mat-input-3")).SendKeys("Croatia");
            driver.FindElement(By.Id("mat-input-4")).Clear();
            driver.FindElement(By.Id("mat-input-4")).SendKeys("Secret");
            driver.FindElement(By.Id("mat-input-5")).Clear();
            driver.FindElement(By.Id("mat-input-5")).SendKeys("0994326767");
            driver.FindElement(By.Id("mat-input-6")).Clear();
            driver.FindElement(By.Id("mat-input-6")).SendKeys("31000");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("Trpimirova 41");
            driver.FindElement(By.Id("mat-input-8")).Clear();
            driver.FindElement(By.Id("mat-input-8")).SendKeys("Osijek");
            driver.FindElement(By.Id("mat-input-9")).Clear();
            driver.FindElement(By.Id("mat-input-9")).SendKeys("Osječko-baranjska");
            driver.FindElement(By.XPath("//button[@id='submitButton']/span")).Click();
            driver.FindElement(By.XPath("//div[@id='card']/app-address/mat-card/mat-table/mat-row/mat-cell[2]")).Click();
            driver.FindElement(By.XPath("//mat-radio-button[@id='mat-radio-42']/label")).Click();
            driver.FindElement(By.XPath("//div[@id='card']/app-address/mat-card/button/span/span")).Click();
            driver.FindElement(By.XPath("//mat-radio-button[@id='mat-radio-45']/label/span/span")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Open side menu'])[1]/preceding::button[1]")).Click();
            driver.FindElement(By.XPath("//mat-expansion-panel-header[@id='mat-expansion-panel-header-2']/span")).Click();
            driver.FindElement(By.XPath("//mat-expansion-panel-header[@id='mat-expansion-panel-header-0']/span/mat-panel-title")).Click();
            driver.FindElement(By.XPath("//div[@id='cdk-accordion-child-0']/div/div/mat-form-field/div/div/div[3]")).Click();
            driver.FindElement(By.Id("mat-input-10")).Click();
            driver.FindElement(By.Id("mat-input-10")).Clear();
            driver.FindElement(By.Id("mat-input-10")).SendKeys("Secret");
            driver.FindElement(By.Id("mat-input-11")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=mat-input-11 | ]]
            driver.FindElement(By.Id("mat-input-11")).Clear();
            driver.FindElement(By.Id("mat-input-11")).SendKeys("51438568690134");
            driver.FindElement(By.Id("mat-input-11")).Click();
            driver.FindElement(By.Id("mat-input-11")).Click();
            driver.FindElement(By.Id("mat-input-11")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=mat-input-11 | ]]
            driver.FindElement(By.Id("mat-input-11")).Clear();
            driver.FindElement(By.Id("mat-input-11")).SendKeys("123456789000");
            driver.FindElement(By.Id("mat-input-12")).Click();
            driver.FindElement(By.Id("mat-input-11")).Click();
            driver.FindElement(By.Id("mat-input-11")).Clear();
            driver.FindElement(By.Id("mat-input-11")).SendKeys("1234567890000000");
            driver.FindElement(By.Id("mat-input-12")).Click();
            new SelectElement(driver.FindElement(By.Id("mat-input-12"))).SelectByText("11");
            driver.FindElement(By.XPath("//option[@value='11']")).Click();
            driver.FindElement(By.Id("mat-input-13")).Click();
            new SelectElement(driver.FindElement(By.Id("mat-input-13"))).SelectByText("2080");
            driver.FindElement(By.XPath("//option[@value='2080']")).Click();
            driver.FindElement(By.Id("submitButton")).Click();
            driver.FindElement(By.XPath("//mat-radio-button[@id='mat-radio-46']/label/span/span")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='OpenSea'])[1]/following::span[7]")).Click();
            driver.FindElement(By.XPath("//button[@id='checkoutButton']/span/span")).Click();
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
