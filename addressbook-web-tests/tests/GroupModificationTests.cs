using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
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
            GroupData newData = new GroupData("sss");
            newData.Header = "xxx";
            newData.Footer = "nnn";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            appManager.Groups.ModifyGroup(0, newData);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                if (groups.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groups.Name);
                }
            }

        }

        [Test]
        public void GroupModificationTestNull()
        {
            if (appManager.Groups.GroupFound())
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

            GroupData newData = new GroupData("aaa");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            appManager.Groups.ModifyGroup(0, newData);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                if (groups.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groups.Name);
                }
            }
        }
    }
}
