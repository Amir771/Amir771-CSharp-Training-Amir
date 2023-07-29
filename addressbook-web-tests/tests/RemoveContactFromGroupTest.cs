using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;


namespace WebAddressBookTests
{
    public class RemoveContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().First();
            List<ContactData> allContactsInGroup = new List<ContactData>();

                if (allContactsInGroup.Count() == 0)
                {
                    appManager.Contacts.AddContactsToGroup(contact, group);
                }
                
                appManager.Contacts.RemoveContactFromGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Remove(contact);

                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            
        }
    }
}
