using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager app;

        //[TestFixtureSetUp]
        [OneTimeSetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        //[TestFixtureTearDown]
        [OneTimeTearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}
