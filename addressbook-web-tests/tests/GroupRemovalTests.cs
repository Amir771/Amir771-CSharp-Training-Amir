using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if(appManager.Groups.GroupFound())
            {
                appManager.Groups.GroupFound();
            }

            else 
            {
                GroupData group = new GroupData("eee");
                group.Header = "uuu";
                group.Footer = "zzz";
                appManager.Groups.CreateGroup(group);
            }

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            
            appManager.Groups.RemoveGroup(0);
            
            List<GroupData> newGroups = appManager.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
