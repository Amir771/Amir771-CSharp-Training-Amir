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
            GroupData newData = new GroupData("sss");
            newData.Header = "xxx";
            newData.Footer = "nnn";

            appManager.Groups.ModifyGroup(1, newData);
            

        }

        [Test]
        public void GroupModificationTestNull()
        {
            GroupData newData = new GroupData("aaa");
            newData.Header = null;
            newData.Footer = null;

            appManager.Groups.ModifyGroup(1, newData);


        }
    }
}
