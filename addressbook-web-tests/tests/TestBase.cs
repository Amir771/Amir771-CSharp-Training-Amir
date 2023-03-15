using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAddressBookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;

       protected ApplicationManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new ApplicationManager();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));

        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
    }
}
