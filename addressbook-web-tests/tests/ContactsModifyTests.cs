using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsModifyTests : AuthTestBase
    {
        [Test]
        public void ContactsModifyTest()
        {
            if (appManager.Contacts.ContactFound())
            {
                ContactData newData = new ContactData("zzz");
                newData.Lastname = "eee";
                appManager.Contacts.ModifyContact(1, newData);
            }
            else
            {
                ContactData newContact = new ContactData("vvv");
                newContact.Lastname = "hhh";
                appManager.Contacts.CreateContact(newContact);

                ContactData newData = new ContactData("zzz");
                newData.Lastname = "eee";
                appManager.Contacts.ModifyContact(1, newData);
            }
            
        }

        [Test]
        public void ContactsModifyTestNull()
        {
            if (appManager.Contacts.ContactFound())
            {
                ContactData newData = new ContactData("nnn");
                newData.Lastname = null;
                appManager.Contacts.ModifyContact(1, newData);
            }
            else
            {
                ContactData newContact = new ContactData("zzz");
                newContact.Lastname = "eee";
                appManager.Contacts.CreateContact(newContact);

                ContactData newData = new ContactData("nnn");
                newData.Lastname = null;
                appManager.Contacts.ModifyContact(1, newData);
            }
        }
    }
}
