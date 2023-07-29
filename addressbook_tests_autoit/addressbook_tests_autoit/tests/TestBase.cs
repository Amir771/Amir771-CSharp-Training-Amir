using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager appManager;

        [SetUp]

        public void initApplication()
        {
            appManager = new ApplicationManager();
        }

        [TearDown]
        public void StopApplication()
        {
            appManager.Stop();
        }
    }
}
