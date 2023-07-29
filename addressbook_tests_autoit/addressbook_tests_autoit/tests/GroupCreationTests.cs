using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "Test"
            };

            appManager.Groups.AddGroup(newGroup);
            List<GroupData> newGroups = appManager.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }
    }
}
