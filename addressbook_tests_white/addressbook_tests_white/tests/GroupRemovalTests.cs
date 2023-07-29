using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //app.Groups.CheckForGruop();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
