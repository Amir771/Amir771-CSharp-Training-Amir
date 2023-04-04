using NUnit.Framework;
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
            ContactData newData = new ContactData("zzz");
            newData.Lastname = "eee";

            appManager.Contacts.ModifyContact(1, newData);
        }

        [Test]
        public void ContactsModifyTestNull()
        {
            ContactData newData = new ContactData("nnn");
            newData.Lastname = null;

            appManager.Contacts.ModifyContact(1, newData);
        }
    }
}
