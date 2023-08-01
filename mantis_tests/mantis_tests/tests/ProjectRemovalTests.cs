using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root",
            };

            ProjectData project;

            List<ProjectData> oldProject = app.API.GetProjectList(account);

            if (oldProject.Count == 0)
            {
                project = new ProjectData("Проект для удаления", "Описание");
                app.API.CheckForProject(account, project);
            }

            List<ProjectData> newProject = app.API.GetProjectList(account);

            app.Project.Remove();

            List<ProjectData> RemoveProject = app.API.GetProjectList(account);

            newProject.RemoveAt(0);
            Assert.AreEqual(newProject, RemoveProject);

        }
    }
}
