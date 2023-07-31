using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToLoginPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }
        public void GoToManagePage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.fa.fa-gears.menu-icon")).Click();
        }
        public void GoToManageProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
