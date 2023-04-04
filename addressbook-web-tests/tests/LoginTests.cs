using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValiedCredentials()
        {
            appManager.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            appManager.Auth.Login(account);
            Assert.IsTrue(appManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvaliedCredentials()
        {
            appManager.Auth.Logout();
            AccountData account = new AccountData("admin", "123456");
            appManager.Auth.Login(account);
            Assert.IsFalse(appManager.Auth.IsLoggedIn(account));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
    }
}
