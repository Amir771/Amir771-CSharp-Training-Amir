using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsModifyTests : ContactTestBase
    {
        [Test]
        public void ContactsModifyTest()
        {
            if (appManager.Contacts.ContactFound())
            {
                appManager.Contacts.ContactFound();
            }
            else
            {
                ContactData newContact = new ContactData("vvv");
                newContact.Lastname = "hhh";
                appManager.Contacts.CreateContact(newContact);
            }

            ContactData newData = new ContactData("zzz");
            newData.Lastname = "eee";

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];
            appManager.Contacts.Modify(oldData, newData);

            List<ContactData> changeContact = ContactData.GetAll();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            changeContact.Sort();
            Assert.AreEqual(oldContact, changeContact);

        }

        [Test]
        public void ContactsModifyTestNull()
        {
            if (appManager.Contacts.ContactFound())
            {
                appManager.Contacts.ContactFound();
            }
            else
            {
                ContactData newContact = new ContactData("zzz");
                newContact.Lastname = "eee";
                appManager.Contacts.CreateContact(newContact);
            }

            ContactData newData = new ContactData("nnn");
            newData.Lastname = null;

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];
            appManager.Contacts.Modify(oldData, newData);

            List<ContactData> changeContact = ContactData.GetAll();
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            changeContact.Sort();
            Assert.AreEqual(oldContact, changeContact);

        }
    }
}
