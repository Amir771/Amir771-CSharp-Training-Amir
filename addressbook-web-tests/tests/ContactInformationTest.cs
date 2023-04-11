using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformationTableAndEditForm()
        {
            ContactData fromTable = appManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = appManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);
        }

        [Test]
        public void TestContactInformationTableAndDetails()
        {
            ContactData fromTable = appManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromDetails = appManager.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromTable.FullName, fromDetails.FullName);
            Assert.AreEqual(fromDetails.Address, fromTable.Address);
            Assert.AreEqual(fromDetails.AllPhones, fromTable.AllPhones);
        }


    }
}
