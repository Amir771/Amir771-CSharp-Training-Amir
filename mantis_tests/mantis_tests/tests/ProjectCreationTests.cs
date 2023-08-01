using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Principal;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root",
            };

            ProjectData project = new ProjectData(GenerateRandomString(8), "Описание");

            List<ProjectData> oldProject = app.API.GetProjectList(account);

            app.Project.Create(project);

            List<ProjectData> newProject = app.API.GetProjectList(account);
            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }
    }
}
