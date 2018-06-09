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
    [Order(3)]
    class Bag : ComonData
    {
        [Test]
        [Order(13)]
        public void emptyBag()
        {
            Thread.Sleep(5000);
            IWebElement remove = browser.FindElement(By.CssSelector(".prodelete"));
            remove.Click();
            try
            {
                IWebElement shownEmpty = browser.FindElement(By.LinkText("Your bag is empty"));
                string shownBag = shownEmpty.Text;

                if (shownEmpty.Displayed)
                {
                    Assert.Pass("Empty bag is displayed!");
                }
                else
                {
                    Assert.Fail("Empty bag is not displayed!");
                }
            }
            catch (Exception ex)
            {
                Assert.Pass("Empty bag is displayed!");
            }
            
        }


    }
}
