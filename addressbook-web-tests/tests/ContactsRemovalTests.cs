using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
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

            List<ContactData> oldContacts = appManager.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            appManager.Contacts.RemoveContact(0);

            List<ContactData> newContacts = appManager.Contacts.GetContactList();

            
            oldContacts.RemoveAt(0);
            Assert.AreNotEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
