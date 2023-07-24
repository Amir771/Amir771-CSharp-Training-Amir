using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ContactHelper InitContactDetails(int index) 
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
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
            manager.Navigator.LinkHome();
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
                    IList<IWebElement> spaces = element.FindElements(By.TagName("td"));
                    contactCashe.Add(new ContactData(spaces[2].Text, spaces[1].Text));

                    //contactCashe.Add(new ContactData(element.Text)
                    //{
                    //    Id = element.FindElement(By.ClassName("center"))
                    //    .FindElement(By.TagName("input")).GetAttribute("value")
                    //}); 
                }
            }
            return new List<ContactData>(contactCashe);


        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.LinkHome();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;   
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
                
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.LinkHome();
            InitContactModify(index+2);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };

        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.LinkHome();
            InitContactDetails(index+2);
            driver.FindElements(By.Id("content"));
            string fullName = driver.FindElement(By.TagName("b")).Text;
            string address = driver.FindElement(By.TagName("br(2)")).Text;
            string homePhone = driver.FindElement(By.TagName("br(3)")).Text;
            string mobilePhone = driver.FindElement(By.TagName("br(4)")).Text;
            string workPhone = driver.FindElement(By.TagName("br(5)")).Text;

            return new ContactData(fullName)
            {
                FullName = fullName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };




        }
    }
}
