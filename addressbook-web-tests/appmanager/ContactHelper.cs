using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            InitContactModify(p + 2);
            FillNewContact(newData);
            SubmitContactModify();
            manager.Navigator.LinkHome();
            return this;

        }

        public void AddContactsToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.LinkHome();
            ClearGroupFilter();
            SelectContactId(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContactId(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
            driver.FindElement(By.XPath("(//table[@id='maintable']/tbody/tr/td/input[@name='selected[]'])[" + (value + 1) + "]")).Click(); ;
            return this;
        }

        public ContactHelper InitContactModify(int index)
        {
            driver.FindElement(By.XPath("//tr[" + index + "]/td[8]/a/img")).Click();
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
            InitContactModify(index + 2);
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


        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.LinkHome();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6]
            .FindElement(By.TagName("a")).Click();

            string allData = (driver.FindElement(By.Id("content")).Text);
            return allData;
        }




        public string GetContactGluedInformationFromEditForm(int index)
        {
            manager.Navigator.LinkHome();
            InitContactModify(index + 2);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string fullName;
            if (firstName != "" && lastName == "")
            {
                fullName = firstName + "\r\n";
            }
            else if (firstName == "" && lastName != "")
            {
                fullName = lastName + "\r\n";
            }
            else if (firstName == "" && lastName == "")
            {
                fullName = "";
            }
            else
            {
                fullName = firstName + " " + lastName + "\r\n";
            }

            if (address != "")
            {
                address = address + "\r\n\r\n";
            }
            else
            {
                address = "";
            }

            if (homePhone != "")
            {
                homePhone = "H: " + homePhone + "\r\n";
            }
            else
            {
                homePhone = "";
            }
            if (mobilePhone != "")
            {
                mobilePhone = "M: " + mobilePhone + "\r\n";
            }
            else
            {
                mobilePhone = "";
            }
            if (workPhone != "")
            {
                workPhone = "W: " + workPhone + "\r\n\r\n";
            }
            else
            {
                workPhone = "";
            }

            string allEmails;

            if (email != "" && email2 != "" && email3 != "")
            {
                allEmails = email + "\r\n" + email2 + "\r\n" + email3;
            }
            else if (email == "" && email2 != "" && email3 != "")
            {
                allEmails = email2 + "\r\n" + email3; 
            }
            else if (email == "" && email2 == "" && email3 != "")
            {
                allEmails = email3;
            }
            else if (email != "" && email2 != "" && email3 == "")
            {
                allEmails = email + "\r\n" + email2;
            }
            else if (email != "" && email2 == "" && email3 == "")
            {
                allEmails = email;
            }
            else if (email == "" && email2 != "" && email3 == "")
            {
                allEmails = email2;
            }
            else
            {
                allEmails = "";
            }

             
            string allEditData = fullName + address + homePhone + mobilePhone + workPhone + allEmails;
            return allEditData;

        }

        
    }
}
