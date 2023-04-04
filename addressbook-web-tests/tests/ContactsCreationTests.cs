using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("aab");
            contact.Lastname = "bbb";

            appManager.Contacts.CreateContact(contact);
            
        }

        [Test]
        public void EmptyContactCreationTests()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = "";

            appManager.Contacts.CreateContact(contact);

        }
    }
}

