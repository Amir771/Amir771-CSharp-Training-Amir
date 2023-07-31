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
            app.Project.CheckForProject();

            List<ProjectData> oldProject = app.Project.GetProjectList();

            app.Project.Remove();

            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);

        }
    }
}
