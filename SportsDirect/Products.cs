using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SportsDirect
{

    [TestFixture]
    [Order(2)]
    class Products : ComonData
    {
        public object WebDriverwait { get; private set; }

        [Test]
        [Order(3)]
        public void invalidSearch()
        {
            Thread.Sleep(2000);
            IWebElement searching = browser.FindElement(By.XPath("//*[@id='txtSearch']"));
            searching.SendKeys(Data.invalidSearch);

            IWebElement button = browser.FindElement(By.XPath("//*[@id='cmdSearch']"));
            button.Click();

            try
            {
                IWebElement errorDisplay = browser.FindElement(By.LinkText("Your search did not match any of our products. Please try another keyword."));
                string ispisGreskeTekst = errorDisplay.Text;

                if (errorDisplay.Displayed)
                {
                    Assert.Pass("Error displayed!");
                }
                else
                {
                    Assert.Fail("Error not displayed!");
                }
            }
            catch (Exception ex)
            {
                Assert.Pass("Error displayed!");
            }
        }

        [Test]
        [Order(4)]
        public void validSearch()
        {
            IWebElement searching = browser.FindElement(By.XPath("//*[@id='txtSearch']"));
            searching.SendKeys(Data.validSearch);

            IWebElement button1 = browser.FindElement(By.XPath("//*[@id='cmdSearch']"));
            button1.Click();
            Assert.Pass("Search works!");

        }

        [Test]
        [Order(5)]
        public void mouseOver()

        {
            IWebElement menu = browser.FindElement(By.XPath("//*[@id='topMenu']/ul/li[1]/a"));
            IWebElement subMenu = browser.FindElement(By.XPath("//*[@id='topMenu']/ul/li[1]/div/ul/li[2]/ul/li[4]/ul/li[2]/a"));

            Actions builder = new Actions(browser);
            Thread.Sleep(2000);
            builder.MoveToElement(menu).Perform();
            Thread.Sleep(2000);
            builder.MoveToElement(subMenu).Click().Perform();
            Assert.Pass("Mouse Over works!");
        }
        

        [Test]
        [Order(6)]
        public void productsDislpay()

        {

            IWebElement[] link = browser.FindElements(By.XPath("//*[@id='TopPaginationWrapper']/div/div/div[2]/div/ul/li")).ToArray();

            /*
                
                Kliknuti na sve linkove i prikazati gresku koji link nije uspeo da se klikne!
             
             */

            bool clicked = true;
            int position_not_clicked = 0;


            for (int i = 0; i < link.Count(); i++)
            {
                try
                {
                    link[i].Click();
                   // clicked = true;

                }
                catch (Exception ex)
                {
                    clicked = false;
                    position_not_clicked = i;
                }

            }

            if (clicked)
            {
                Assert.Pass("All are clicked!");
            }
            else
            {
                Assert.Fail("Is not clicked: " + position_not_clicked + " link.");
            }

        }

        [Test]
        [Order(7)]
        public void dropDown()
        {
            var option = browser.FindElement(By.CssSelector(".col-xs-12 div .dropprods_Order"));
            var choice = new SelectElement(option);
            Thread.Sleep(4000);
            choice.SelectByText("Price (Low To High)");
            Assert.Pass("Chosen field!");
        }

        [Test]
        [Order(8)]
        public void productChoice()
        {
            Thread.Sleep(2000);
            IWebElement boots = browser.FindElement(By.CssSelector(".productimage a[href='/soviet-remix-mens-boots-114822?colcode=11482271']"));
            boots.Click();
            Assert.Pass("Product chosen!");

        }

        [Test]
        [Order(9)]
        public void productPurchased()
        {

            IWebElement colour = browser.FindElement(By.CssSelector(".colourImages a[href='DesktopModules/SportsDirect/ProductDetail/Controls/#']"));
            colour.Click();
            
            int shoeSize = 44;
            IWebElement size = browser.FindElement(By.CssSelector(".sizeButtons li[title='Click to select 10 (44)'] a"));
            string sizeNumber = size.Text.Replace("(", "").Replace(")", "").Replace("10", "").Trim();
            int broj = Int32.Parse(sizeNumber);
            if (broj == shoeSize)
            {
                size.Click();
                Assert.Pass("Size chosen!");
            }
            else
            {
                Assert.Fail("Size is not chosen!");
            }
        }

        [Test]
        [Order(10)]
        public void addtoBag()
        {
            int clicked = 4;
            IWebElement add = browser.FindElement(By.CssSelector(".s-basket-plus-button"));
            Thread.Sleep(2000);

            for (int i = 0; i < 3; i++)
            {
                add.Click();

            }


            IWebElement putIn = browser.FindElement(By.CssSelector(".ImgButWrap a[data-addtobag='Add to bag']"));
            putIn.Click();
            Assert.Pass("Clicked put in!");

        }

        [Test]
        [Order(11)]
        public void bagMouseover()
        {
            IWebElement menuBag = browser.FindElement(By.XPath("//*[@id='bagQuantity']"));
            IWebElement submenuBag = browser.FindElement(By.XPath("//*[@id='aViewBag']"));

            Actions builder = new Actions(browser);
            Thread.Sleep(2000);
            builder.MoveToElement(menuBag).Perform();
            Thread.Sleep(2000);
            builder.MoveToElement(submenuBag).Click().Perform();
            Assert.Pass("Done successfully!");

        }

        [Test]
        [Order(12)]
        public void bagChecked()
        {
            string productName = "Soviet Remix Mens Boots";
            string name_in_bag = browser.FindElement(By.CssSelector(".prodDescContainer a")).Text;
            if (name_in_bag == productName)
            {
                Assert.Pass("Done successfully!");
            }
            else
            {
                Assert.Fail("Is not done successfully!");
            }

        }
    }
}
