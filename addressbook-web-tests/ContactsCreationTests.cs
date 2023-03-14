using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            FillNewContact(new ContactData("aab", "bbc"));
            SubmitNewContact();
            Logout();
        }
   }
}

