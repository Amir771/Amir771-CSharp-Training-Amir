using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.InitNewContactCreation();
            FillNewContact(contact);
            SubmitNewContact();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.LinkHome();
            SelectContact(p);
            RemoveContact();
            manager.Navigator.LinkHome();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper ModifyContact(int p, ContactData newData)
        {
            manager.Navigator.LinkHome();
            SelectContact(p+1);
            InitContactModify(p+1);
            FillNewContact(newData);
            SubmitContactModify();
            manager.Navigator.LinkHome();
            manager.Auth.Logout();
            return this;

        }
        
        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillNewContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int num)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            //driver.FindElement(By.XPath("(//div[@id='maintable']/tbody/td.center/input/[@name='selected[]'])[" + num + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModify(int index)
        {
            driver.FindElement(By.XPath("//tr["+ index +"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
