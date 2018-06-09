using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDirect
{
    class ComonData
    {
        public static IWebDriver browser = new ChromeDriver();

        public Data Data;

        public ComonData()
        {
            Data = new Data();

        }
    }
}
