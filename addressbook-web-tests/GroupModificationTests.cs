using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("sss");
            newData.Header = "zzz";
            newData.Footer = "vvv";

            appManager.Groups.ModifyGroup(1, newData);
            

        }
    }
}
