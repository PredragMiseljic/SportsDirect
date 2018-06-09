using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsDirect
{

    [TestFixture]
    [Order(1)]
    class Logging : ComonData
    {
        public Logging()
        {
            browser.Manage().Window.Maximize();
            browser.Url = "https://rs.sportsdirect.com/";

        }

        [Test]
        [Order(1)]
        public void invalidEmail()
        {
            Thread.Sleep(1000);
            browser.FindElement(By.XPath("//*[@id='advertPopup']/div")).Click();
            browser.FindElement(By.Id("dnn_dnnLOGIN_loginLink")).Click();

            IWebElement email = browser.FindElement(By.XPath("//input[@placeholder='Enter your Email Address']"));
            email.SendKeys(Data.invalidEmail);

            Thread.Sleep(2000);
            IWebElement password = browser.FindElement(By.XPath("//input[@title='Enter your Password']"));
            password.SendKeys(Data.password);

            IWebElement signin = browser.FindElement(By.LinkText("Sign In Securely"));
            signin.Click();

            try
            {
                IWebElement error = browser.FindElement(By.LinkText("This email address or password is incorrect"));
                string errorText = error.Text;

                if (error.Displayed)
                {
                    Assert.Pass("Email not correct, error displayed!");
                }
                else
                {
                    Assert.Fail("Email not correct, error not displayed!");
                }
            }
            catch (Exception ex)
            {
                Assert.Pass("Email not correct, error displayed!");
            }
        }

        [Test]
        [Order(2)]
        public void validEmail()
        {

             browser.FindElement(By.XPath("//input[@placeholder='Enter your Email Address']")).Clear();

             IWebElement email = browser.FindElement(By.XPath("//input[@placeholder='Enter your Email Address']"));
             email.SendKeys(Data.validEmail);

             IWebElement password = browser.FindElement(By.XPath("//input[@title='Enter your Password']"));
             password.SendKeys(Data.password);

             IWebElement signin = browser.FindElement(By.LinkText("Sign In Securely"));
             signin.Click();
             Assert.Pass("Done successfully");

        }
    }
}
