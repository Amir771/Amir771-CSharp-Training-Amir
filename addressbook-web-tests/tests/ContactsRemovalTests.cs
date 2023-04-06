using System;
using System.Collections.Generic;
using System.Linq;
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
                appManager.Contacts.RemoveContact(1);
            }
            else
            {
                ContactData newContact = new ContactData("vvv");
                newContact.Lastname = "hhh";
                appManager.Contacts.CreateContact(newContact);

                appManager.Contacts.RemoveContact(1);
            }
        }
    }
}
