using mantis_tests.Mantis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "12"
            };
            IssueData issue = new IssueData()
            {
                Category = "General",
                Summary = "some short text",
                Description = "some long text"
            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
