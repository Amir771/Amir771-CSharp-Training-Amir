using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void GroupCreationTests()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            appManager.Groups.CreateGroup(group);
            
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            appManager.Groups.CreateGroup(group);
            
        }
    }
}
