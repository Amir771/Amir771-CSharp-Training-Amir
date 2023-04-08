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
            InitContactModify(p+2);
            FillNewContact(newData);
            SubmitContactModify();
            manager.Navigator.LinkHome();
            return this;

        }
        
        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;
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
            contactCashe = null;
            return this;
        }

        public ContactHelper SelectContact(int value)
        {
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody/tr/td/input[@name='selected[]'])[" + (value+1) + "]")).Click();;
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
            contactCashe = null;
            return this;
        }

        public bool ContactFound()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.LinkHome();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    //IList<IWebElement> spaces = element.FindElements(By.TagName("td"));
                    //contactCashe.Add(new ContactData(spaces[2].Text, spaces[1].Text));

                    contactCashe.Add(new ContactData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCashe);


        }
    }
}
