using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.smaller-75"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.TagName("span")).Text == account.Username;
            
        }
    }
}
