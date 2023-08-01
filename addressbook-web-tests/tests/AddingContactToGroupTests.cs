using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            appManager.Groups.CheckForGroupForAdd();
            appManager.Contacts.CheckForContactForAdd();

            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();
            
            var found = false;
            ContactData foundContact = null;
            GroupData foundGroup = null;

            foreach (var group in groups)
            {
                foreach (var contact in contacts)
                {
                    if (!group.GetContacts().Contains(contact))
                    {
                        foundContact = contact;
                        foundGroup = group;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                appManager.Contacts.CreateContact(new ContactData(GenerateRandomString(8), GenerateRandomString(8)));
                List<ContactData> oldContacts = ContactData.GetAll();
                foundGroup = groups[0];
                foundContact = oldContacts.Except(contacts).First();
            }

            List<ContactData> oldList = foundGroup.GetContacts();
            appManager.Contacts.AddContactsToGroup(foundContact, foundGroup);
            List<ContactData> newList = foundGroup.GetContacts();
            oldList.Add(foundContact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);


        }
    }
}
