using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using mantis_tests.Mantis;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            issue.category = issueData.Category;
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            client.mc_issue_add(account.Username, account.Password, issue);
        }
        public List<ProjectData> GetProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] elements = client.mc_projects_get_user_accessible(account.Username, account.Password);

            List<ProjectData> projects = new List<ProjectData>();
            foreach (Mantis.ProjectData element in elements)
            {
                projects.Add(new ProjectData(element.name, element.description)
                {
                    Id = element.id
                });
            }
            return projects;
        }
        public void CheckForProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData newProject = new Mantis.ProjectData
            {
                name = project.Name
            };
            project.Id = client.mc_project_add(account.Username, account.Password, newProject);
        }
    }
}
