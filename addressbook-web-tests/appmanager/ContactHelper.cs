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
            manager.Navigator.LinkHome();
            return this;
        }

        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.LinkHome();
            SelectContact(p);
            RemoveContact();
            manager.Navigator.LinkHome();
            return this;
        }

        public ContactHelper ModifyContact(int p, ContactData newData)
        {
            manager.Navigator.LinkHome();
            SelectContact(p);
            InitContactModify(p+1);
            FillNewContact(newData);
            SubmitContactModify();
            manager.Navigator.LinkHome();
            return this;

        }
        
        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillNewContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int value)
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                return this;
            }
            else
            {
                manager.Navigator.InitNewContactCreation();
                ContactData contact = new ContactData("aab");
                contact.Lastname = "bbb";
                FillNewContact(contact);
                SubmitNewContact();
                manager.Navigator.LinkHome();
            }
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody/tr/td/input[@name='selected[]'])[" + value + "]")).Click();;
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
