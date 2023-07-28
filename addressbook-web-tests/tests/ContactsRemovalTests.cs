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
    public class ContactsRemovalTests : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
            appManager.Contacts.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();

            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
